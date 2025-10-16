using RabbitMQ.Client;

namespace Practice2
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            const string queueName = "BasicTest";
            await channel.QueueDeclareAsync(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = "Getting Started with .NET Core RabbitMQ";
            var body = System.Text.Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                     exchange: "",
                     routingKey: queueName,
                     mandatory: false,
                     body: body);

            Console.WriteLine(" [x] Sent {0}", message);
            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
