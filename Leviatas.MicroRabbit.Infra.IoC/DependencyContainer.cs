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
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Leviatas.MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Here we will register all our dependencies
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();
            // Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }

        public static void RegisterServicesTransfer(IServiceCollection services)
        {
            // Here we will register all our dependencies
            services.AddTransient<IEventBus, RabbitMQBus>();

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
