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

        public List<UsuarioLogin> ReturnUsuario()
        {
            try { return _usuarioRepository.RetornaUsuarios(); }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
