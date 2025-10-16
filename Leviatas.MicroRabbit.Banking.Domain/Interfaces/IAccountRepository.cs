using Leviatas.MicroRabbit.Banking.Domain.Models;

namespace Leviatas.MicroRabbit.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();

    }
}
