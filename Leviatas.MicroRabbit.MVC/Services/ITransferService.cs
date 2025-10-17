using Leviatas.MicroRabbit.MVC.Models.DTO;

namespace Leviatas.MicroRabbit.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transferDTO);
    }
}
