using MessageTestProject.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Formatting = Newtonsoft.Json.Formatting;

namespace MessageTestProject.Messaging
{
    static class Sender
    {
        public static void Send(Message m)
        {
            var hostName = Environment.GetEnvironmentVariable("DR_HOSTNAME");
            var userName = Environment.GetEnvironmentVariable("DR_USERNAME");
            var password = Environment.GetEnvironmentVariable("DR_PASSWORD");
            var outQueue = Environment.GetEnvironmentVariable("DR_QUEUE_IN");

            var factory = new ConnectionFactory() { HostName = hostName, UserName = userName, Password = password };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: outQueue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            string message = JsonConvert.SerializeObject(m, Formatting.Indented);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: outQueue,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent:\n{0}", message);
        }
    }
}
