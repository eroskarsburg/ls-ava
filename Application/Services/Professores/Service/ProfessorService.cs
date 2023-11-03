using Application.Services.Professores.Repository;
using Application.Services.Professores.Service.Abstractions;
using Application.Services.Usuarios.Repository;
using Application.Shared.Entities;

namespace Application.Services.Professores.Service
{
    public class ProfessorService : IProfessorService
    {
        private readonly ProfessorRepository _professorRepository;
        private readonly UsuarioRepository _usuarioRepository;

        public ProfessorService(ProfessorRepository professorRepository, UsuarioRepository usuarioRepository)
        {
            _professorRepository = professorRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Task CreateProfessor(Professor professor, UsuarioLogin usuario)
        {
            try
            {
                _professorRepository.InserirProfessor(professor);
                _usuarioRepository.InserirLogin(usuario);
                return Task.CompletedTask;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public Task DeleteProfessor(string registro)
        {
            try
            {
                _professorRepository.DeletarProfessor(registro);
                _usuarioRepository.DeletarUsuario(registro);
                return Task.CompletedTask;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Professor> ReturnProfessor()
        {
            try { return _professorRepository.RetornaProfessores(); }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public Task UpdateProfessor(Professor professor)
        {
            try
            {
                _professorRepository.AtualizarProfessor(professor);
                return Task.CompletedTask;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
