using Application.Shared.Enum;

namespace Application.Shared.Entities
{
    internal class Aluno
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string? Nome { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
    }
}
