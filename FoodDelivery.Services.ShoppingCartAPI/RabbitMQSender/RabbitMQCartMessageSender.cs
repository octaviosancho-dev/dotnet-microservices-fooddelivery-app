using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace FoodDelivery.Services.ShoppingCartAPI.RabbitMQSender
{
    public class RabbitMQCartMessageSender : IRabbitMQCartMessageSender
    {
        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _vhost;
        private IConnection _connection;
        private readonly IConfiguration _config;

        public RabbitMQCartMessageSender(IConfiguration config)
        {
            _config = config;
            _hostName = _config.GetValue<string>("RabbitMQ:HostName");
            _username = _config.GetValue<string>("RabbitMQ:User");
            _password = _config.GetValue<string>("RabbitMQ:Password");
            _vhost = _config.GetValue<string>("RabbitMQ:VirtualHost");
        }

        public void SendMessage(object message, string queueName)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queueName, false, false, false, null);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: queueName,
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
                    Password = _password,
                    VirtualHost = _vhost
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
