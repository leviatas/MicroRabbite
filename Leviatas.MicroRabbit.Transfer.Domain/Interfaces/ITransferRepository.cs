using Leviatas.MicroRabbit.Transfer.Domain.Models;

namespace Leviatas.MicroRabbit.Banking.Domain.Interfaces
{
    public interface ITransferRepository
    {
        void Add(TransferLog transferLog);
        IEnumerable<TransferLog> GetTransferLogs();

    }
}
