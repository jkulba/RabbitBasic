using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "127.0.0.1", UserName = "guest", Password = "guest"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())  
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                for (int i = 1; i <= 5000; i++)
                {
                    string message = "Hello Joe - " + i + " " + Guid.NewGuid();
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                    Console.WriteLine(message);
                }
            }
            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}




//connectionFactory.UserName = "accountant";
//connectionFactory.Password = "accountant";
//connectionFactory.VirtualHost = "accounting";