using Leviatas.MicroRabbit.Banking.Data.Context;
using Leviatas.MicroRabbit.Banking.Domain.Interfaces;
using Leviatas.MicroRabbit.Transfer.Domain.Models;
namespace Leviatas.MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }
    }
}
