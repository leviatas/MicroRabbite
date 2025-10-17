using Leviatas.MicroRabbit.Banking.Application.Interfaces;
using Leviatas.MicroRabbit.Banking.Application.Services;
using Leviatas.MicroRabbit.Banking.Data.Context;
using Leviatas.MicroRabbit.Banking.Data.Repository;
using Leviatas.MicroRabbit.Banking.Domain.CommandHandlers;
using Leviatas.MicroRabbit.Banking.Domain.Commands;
using Leviatas.MicroRabbit.Banking.Domain.Interfaces;
using Leviatas.MicroRabbit.Domain.Core.Bus;
using Leviatas.MicroRabbit.Infra.Bus;
using Leviatas.MicroRabbit.Transfer.Application.Interfaces;
using Leviatas.MicroRabbit.Transfer.Application.Services;
using Leviatas.MicroRabbit.Transfer.Data.Repository;
using Leviatas.MicroRabbit.Transfer.Domain.EventHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Leviatas.MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                // Using a factory method to resolve dependencies
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                // Create and return the RabbitMQBus instance
                return new RabbitMQBus(sp.GetRequiredService<IMediator>(), scopeFactory);
            });



            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();

            // Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }

        public static void RegisterServicesTransfer(IServiceCollection services)
        {
            // Here we will register all our dependencies
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                // Using a factory method to resolve dependencies
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                // Create and return the RabbitMQBus instance
                return new RabbitMQBus(sp.GetRequiredService<IMediator>(), scopeFactory);
            });

            // Suscriptions
            services.AddTransient<TransferEventHandler>();

            // Domain Handlers
            services.AddTransient<IEventHandler<Transfer.Domain.Events.TransferCreatedEvent>, TransferEventHandler>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            //services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();
            // Data Layer
            //services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
