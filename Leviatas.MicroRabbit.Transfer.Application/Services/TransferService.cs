using Leviatas.MicroRabbit.Banking.Domain.Interfaces;
using Leviatas.MicroRabbit.Domain.Core.Bus;
using Leviatas.MicroRabbit.Transfer.Application.Interfaces;
using Leviatas.MicroRabbit.Transfer.Domain.Models;

namespace Leviatas.MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;
        public TransferService(
            ITransferRepository transferRepository,
            IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }

        //public void Transfer(AccountTransferDTO accountTransfer)
        //{
        //    var createTransferCommand = new CreateTransferCommand(
        //        accountTransfer.FromAccount,
        //        accountTransfer.ToAccount,
        //        accountTransfer.Amount);
        //    _bus.SendCommand(createTransferCommand);
        //}
    }
}
