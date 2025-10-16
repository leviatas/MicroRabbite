using Leviatas.MicroRabbit.Domain.Core.Bus;
using Leviatas.MicroRabbit.Domain.Core.Commands;
using Leviatas.MicroRabbit.Domain.Core.Events;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Leviatas.MicroRabbit.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
        public async void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using (var channel = await connection.CreateChannelAsync())
            {
                var eventName = @event.GetType().Name;
                await channel.QueueDeclareAsync(queue: eventName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonConvert.SerializeObject(@event);
                var body = System.Text.Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(
                     exchange: "",
                     routingKey: eventName,
                     mandatory: false,
                     body: body);
            }


        }


        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            // Register the event type if not already registered
            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            // Ensure there's a list to hold handlers for this event
            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            // Avoid duplicate registrations
            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                ConsumerDispatchConcurrency = 1
            };

            var connection = factory.CreateConnectionAsync();
            var channel = connection.Result.CreateChannelAsync().Result;

            var eventName = typeof(T).Name;
            channel.QueueDeclareAsync(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += Consumer_Received;

            channel.BasicConsumeAsync(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var eventName = @event.RoutingKey;
            var message = Encoding.UTF8.GetString(@event.Body.ToArray());

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                var suscriptions = _handlers[eventName];
                foreach (var suscription in suscriptions)
                {
                    var handler = Activator.CreateInstance(suscription);
                    if (handler == null) continue;
                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                }
            }
        }
    }
}
