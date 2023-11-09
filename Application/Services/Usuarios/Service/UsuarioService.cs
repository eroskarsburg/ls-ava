using Application.Services.Usuarios.Repository;
using Application.Shared.Entities;

namespace Application.Services.Usuarios.Service
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public static List<UsuarioLogin> ReturnUsuario()
        {
            try { return UsuarioRepository.RetornaUsuarios(); }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
