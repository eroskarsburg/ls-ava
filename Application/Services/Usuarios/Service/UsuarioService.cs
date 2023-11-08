using Application.Services.Usuarios.Repository;
using Application.Shared.Entities;

namespace Application.Services.Usuarios.Service
{
    public class UsuarioService
    {
        private readonly DisciplinaRepository _usuarioRepository;

        public UsuarioService(DisciplinaRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public static List<UsuarioLogin> ReturnUsuario()
        {
            try { return DisciplinaRepository.RetornaUsuarios(); }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
