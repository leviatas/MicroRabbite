using Leviatas.MicroRabbit.Domain.Core.Events;

namespace Leviatas.MicroRabbit.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event

    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
