using Application.Services.Alunos.Repository;
using Application.Services.Alunos.Service.Abstractions;
using Application.Services.Usuarios.Repository;
using Application.Shared.Entities;

namespace Application.Services.Alunos.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly AlunoRepository _alunoRepository;
        private readonly DisciplinaRepository _usuarioRepository;

        public AlunoService(AlunoRepository alunoRepository, DisciplinaRepository usuarioRepository)
        {
            _alunoRepository = alunoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Task CreateAluno(Aluno aluno, UsuarioLogin usuario)
        {
            try
            {
                _alunoRepository.InserirAluno(aluno);
                _usuarioRepository.InserirLogin(usuario);
                return Task.CompletedTask;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Aluno> ReturnAluno()
        {
            try { return _alunoRepository.RetornaAlunos(); }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public Task UpdateAluno(Aluno aluno)
        {
            try
            {
                _alunoRepository.AtualizarAluno(aluno);
                return Task.CompletedTask;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public Task DeleteAluno(string matricula)
        {
            try
            {
                _alunoRepository.DeletarAluno(matricula);
                _usuarioRepository.DeletarUsuario(matricula);
                return Task.CompletedTask;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
