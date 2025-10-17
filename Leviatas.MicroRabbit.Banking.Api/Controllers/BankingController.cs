using Leviatas.MicroRabbit.Banking.Application.Interfaces;
using Leviatas.MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leviatas.MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<BankingController> _logger;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Account>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            try
            {
                var accounts = _accountService.GetAccounts();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving accounts");
            }
        }
    }
}