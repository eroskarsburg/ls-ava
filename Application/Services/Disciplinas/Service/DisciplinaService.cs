using Application.Services.Disciplinas.Repository;
using Application.Services.Usuarios.Repository;
using Application.Shared.Entities;

namespace Application.Services.Disciplinas.Service
{
    public class DisciplinaService
    {
        private readonly DisciplinaRepository _disciplinaRepository;

        public DisciplinaService(DisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public static Dictionary<int, List<Disciplina>> ReturnDisciplinas()
        {
            try { return DisciplinaRepository.RetornaDisciplinas(); }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
