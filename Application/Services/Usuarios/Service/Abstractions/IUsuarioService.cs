using Application.Shared.Entities;

namespace Application.Services.Usuarios.Service.Abstractions
{
    public interface IUsuarioService
    {
        List<UsuarioLogin> ReturnUsuario();
    }
}
