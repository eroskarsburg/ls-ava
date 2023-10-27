using ls_ava_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ls_ava_web.Controllers
{
    public class RecuperarSenhaController : Controller
    {
        private readonly ILogger<RecuperarSenhaController> _logger;

        public RecuperarSenhaController(ILogger<RecuperarSenhaController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}