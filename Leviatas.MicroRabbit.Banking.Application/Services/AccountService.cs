using Leviatas.MicroRabbit.Banking.Api.Controllers;
using Leviatas.MicroRabbit.Banking.Application.Interfaces;
using Leviatas.MicroRabbit.Banking.Domain.Commands;
using Leviatas.MicroRabbit.Banking.Domain.Interfaces;
using Leviatas.MicroRabbit.Banking.Domain.Models;
using Leviatas.MicroRabbit.Domain.Core.Bus;

namespace Leviatas.MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;
        public AccountService(
            IAccountRepository accountRepository,
            IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransferDTO accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.Amount);
            _bus.SendCommand(createTransferCommand);
        }
    }
}
