using Leviatas.MicroRabbit.Infra.IoC;

namespace Leviatas.MicroRabbit.Transfer.Api.Extensions
{
    public static class Extensions
    {
        public static void RegisterServices(this IHostApplicationBuilder builder)
        {
            DependencyContainer.RegisterServicesTransfer(builder.Services);
        }
    }
}
