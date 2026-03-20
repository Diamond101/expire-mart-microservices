using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace NotificationService;

public class ProductCreatedEvent
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
}

public class ConsumerService
{
    public void Start()
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare("ProductCreatedEvent", false, false, false);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var json = Encoding.UTF8.GetString(ea.Body.ToArray());
            var evt = JsonConvert.DeserializeObject<ProductCreatedEvent>(json);

            Console.WriteLine($"📧 Notification: {evt.Name} created!");
        };

        channel.BasicConsume("ProductCreatedEvent", true, consumer);
    }
}