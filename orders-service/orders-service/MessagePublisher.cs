using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OrdersService.Messaging
{
    public class MessagePublisher
    {
        private readonly IConfiguration _configuration;

        public MessagePublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PublishMessage(string message, string routingKey)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", // RabbitMQ host
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "order_exchange", type: "direct");

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "order_exchange",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
