using Leviatas.MicroRabbit.Domain.Core.Bus;
using Leviatas.MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Leviatas.MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Here we will register all our dependencies
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
