using Application.Shared.Entities;

namespace Application.Services.Professores.Service.Abstractions
{
    public interface IProfessorService
    {
        Task CreateProfessor(Professor professor, UsuarioLogin usuario);
        List<Professor> ReturnProfessor();
        Task UpdateProfessor(Professor professor);
        Task DeleteProfessor(string registro);
    }
}
