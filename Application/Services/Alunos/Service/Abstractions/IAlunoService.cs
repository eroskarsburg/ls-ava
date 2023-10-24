using Application.Shared.Entities;

namespace Application.Services.Alunos.Service.Abstractions
{
    internal interface IAlunoService
    {
        Task CreateAluno(Aluno aluno);
        Task ReturnAluno();
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(string matricula);
    }
}
