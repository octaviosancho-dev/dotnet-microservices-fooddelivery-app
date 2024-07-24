using Azure.Messaging.ServiceBus;
using Mango.Services.EmailAPI.Models.Dto;
using Mango.Services.EmailAPI.Services;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Services.EmailAPI.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string emailCartQueue;
        private readonly string registerUserQueue;
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;

        private ServiceBusProcessor _emailCartProccesor;
        private ServiceBusProcessor _registerUserProccesor;

        public AzureServiceBusConsumer(IConfiguration configuration, EmailService emailService)
        {
            _emailService = emailService;
            _configuration = configuration;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");

            emailCartQueue = _configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue");
            registerUserQueue = _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue");

            var client = new ServiceBusClient(serviceBusConnectionString);
            _emailCartProccesor = client.CreateProcessor(emailCartQueue);
            _registerUserProccesor = client.CreateProcessor(registerUserQueue);
        }

        public async Task Start()
        {
            _emailCartProccesor.ProcessMessageAsync += OnEmailCartRequestReceived;
            _emailCartProccesor.ProcessErrorAsync += ErrorHandler;
            await _emailCartProccesor.StartProcessingAsync();

            _registerUserProccesor.ProcessMessageAsync += OnRegisterUserRequestReceived;
            _registerUserProccesor.ProcessErrorAsync += ErrorHandler;
            await _registerUserProccesor.StartProcessingAsync();
        }


        public async Task Stop()
        {
            await _emailCartProccesor.StopProcessingAsync();
            await _emailCartProccesor.DisposeAsync();

            await _registerUserProccesor.StopProcessingAsync();
            await _registerUserProccesor.DisposeAsync();
        }

        private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs args)
        {
            // this is where we receive the message
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(body);
            try
            {
                await _emailService.EmailCartAndLog(objMessage);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task OnRegisterUserRequestReceived(ProcessMessageEventArgs args)
        {
            // this is where we receive the message
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            string email = JsonConvert.DeserializeObject<string>(body);
            try
            {
                await _emailService.RegisterUserEmailAndLog(email);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
