using Leviatas.MicroRabbit.Transfer.Domain.Models;

namespace Leviatas.MicroRabbit.Banking.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();

    }
}
