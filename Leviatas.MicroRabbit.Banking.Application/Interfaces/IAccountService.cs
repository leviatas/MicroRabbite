using Leviatas.MicroRabbit.Banking.Domain.Models;

namespace Leviatas.MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
