using Leviatas.MicroRabbit.Banking.Api.Controllers;
using Leviatas.MicroRabbit.Banking.Domain.Models;

namespace Leviatas.MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransferDTO accountTransfer);
    }
}
