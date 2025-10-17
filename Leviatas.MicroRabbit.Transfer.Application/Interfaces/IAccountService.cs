using Leviatas.MicroRabbit.Transfer.Domain.Models;

namespace Leviatas.MicroRabbit.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
        //void Transfer(TransferTransferDTO accountTransfer);
    }
}
