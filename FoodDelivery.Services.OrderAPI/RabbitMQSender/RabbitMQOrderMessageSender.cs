using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace FoodDelivery.Services.OrderAPI.RabbitMQSender
{
    public class RabbitMQOrderMessageSender : IRabbitMQOrderMessageSender
    {
        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;
        private IConfiguration _config;
        private const string OrderCreated_RewardsUpdateQueue = "RewardsUpdateQueue";
        private const string OrderCreated_EmailUpdateQueue = "EmailUpdateQueue";

        public RabbitMQOrderMessageSender()
        {
            _hostName = _config.GetValue<string>("RabbitMQ:HostName");
            _username = _config.GetValue<string>("RabbitMQ:User");
            _password = _config.GetValue<string>("RabbitMQ:Password");
        }

        public void SendMessage(object message, string exchangeName)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: false);
                channel.QueueDeclare(OrderCreated_EmailUpdateQueue, false, false, false, null);
                channel.QueueDeclare(OrderCreated_RewardsUpdateQueue, false, false, false, null);

                channel.QueueBind(OrderCreated_EmailUpdateQueue, exchangeName, "EmailUpdate");
                channel.QueueBind(OrderCreated_RewardsUpdateQueue, exchangeName, "RewardsUpdate");

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(
                    exchange: exchangeName,
                    "EmailUpdate",
                    null,
                    body: body);
                
                channel.BasicPublish(
                    exchange: exchangeName,
                    "RewardsUpdate",
                    null,
                    body: body);
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _username,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                
            }
        }

        private bool ConnectionExists()
        {
            if (_connection == null)
            {
                CreateConnection();
                return true;
            }
            return true;
        }
    }
}
