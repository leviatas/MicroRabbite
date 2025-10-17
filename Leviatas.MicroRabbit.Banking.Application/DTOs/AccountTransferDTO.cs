namespace Leviatas.MicroRabbit.Banking.Api.Controllers
{
    public class AccountTransferDTO
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal Amount { get; set; }
    }
}