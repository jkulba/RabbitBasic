using System;
using System.IO;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.86.246", UserName = "guest", Password = "guest"};
            string message = "";
            string jsonFilePath = @"C:\Users\jkulba\Projects\RabbitBasic\samples\ElectrodeTestRequest.json";
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                message = r.ReadToEnd();
            }

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())  
            {
                channel.QueueDeclare(queue: "CoreToProcessorImpedanceData", durable: true, exclusive: false, autoDelete: false, arguments: null);

                for (int i = 1; i <= 10000; i++)
                {
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "HUv1Backend", routingKey: "CoreToProcessorImpedanceData", basicProperties: null, body: body);
                    //Console.WriteLine(message);
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