using Leviatas.MicroRabbit.Domain.Core.Commands;

namespace Leviatas.MicroRabbit.Banking.Domain.Commands
{
    public class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
    }
}
