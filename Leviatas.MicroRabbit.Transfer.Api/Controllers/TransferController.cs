using Leviatas.MicroRabbit.Transfer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Leviatas.MicroRabbit.Transfer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;


        private readonly ILogger<TransferController> _logger;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        //[HttpGet("GetTransferLogs", Name = "GetTransferLogs")]
        [HttpGet(Name = "GetTransferLogs")]
        public IActionResult Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
