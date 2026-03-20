using Microsoft.AspNetCore.Connections;
using System.Text;

namespace ProductService.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event);
    }

    public class RabbitMqEventBus : IEventBus
    {
        private readonly IModel _channel;

        public RabbitMqEventBus()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public Task PublishAsync<T>(T @event)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            _channel.QueueDeclare(typeof(T).Name, false, false, false);

            _channel.BasicPublish("", typeof(T).Name, null, body);

            return Task.CompletedTask;
        }
    }
}
