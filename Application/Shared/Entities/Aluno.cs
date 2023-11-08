using Application.Shared.Enum;

namespace Application.Shared.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public int Matricula { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public Dictionary<int, List<Disciplina>>? DisciplinasPorModulo;
    }
}
