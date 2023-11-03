using Application.Shared.Entities;

namespace Application.Services.Alunos.Service.Abstractions
{
    public interface IAlunoService
    {
        Task CreateAluno(Aluno aluno, UsuarioLogin usuario);
        List<Aluno> ReturnAluno();
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(string matricula);
    }
}
