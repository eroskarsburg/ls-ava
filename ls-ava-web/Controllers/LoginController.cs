using ls_ava_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ls_ava_web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        #region [ Services ]
        //[HttpPost]
        //public async Task<IActionResult> PostValidaLogin([FromBody] UsuarioEntidade usuario)
        //{
        //    var response = await apiCliente.GetLoginApiData($"Login/ValidarLogin", usuario);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response.Data);
        //    }
        //    else
        //    {
        //        return BadRequest(response.MenssagemErro);
        //    }
        //}
        #endregion
    }
}