using Application.Services.Usuarios.Repository;
using Application.Services.Usuarios.Service;
using Application.Shared.Context;
using Application.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WepAppAva.Pages
{
    public class UsuarioModel : PageModel
    {
        private readonly ILogger<UsuarioModel> _logger;
        public List<UsuarioLogin>? Usuarios { get; set; }

        public UsuarioModel(ILogger<UsuarioModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            DbContext.DBConnect();
            List<UsuarioLogin> usuario = UsuarioService.ReturnUsuario();
            Usuarios = usuario;
            return Page();
        }
    }
}