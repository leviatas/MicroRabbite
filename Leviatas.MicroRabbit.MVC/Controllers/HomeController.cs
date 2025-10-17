using Leviatas.MicroRabbit.MVC.Models;
using Leviatas.MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Leviatas.MicroRabbit.MVC.Controllers
{
    public class HomeController : Controller
    {
        //inject transfer service
        private readonly ITransferService _transferService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITransferService transferService)
        {
            _logger = logger;
            _transferService = transferService;
        }

        public IActionResult Index(string status)
        {
            ViewBag.status = status;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            var transferDTO = new Models.DTO.TransferDTO
            {
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferAmount = model.TransferAmount
            };
            try
            {
                await _transferService.Transfer(transferDTO);

                // Redirect to home view
                return RedirectToAction("Index", new { Status = "Exitoso" });

            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { Status = "Fallido" });
            }

        }
    }
}
