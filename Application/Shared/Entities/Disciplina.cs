namespace Application.Shared.Entities
{
    public class Disciplina
    {
        public int Id { get; set; }
        public int? IdModulo { get; set; }
        public string? NomeDisciplina { get; set; }
        public string? Requisitos { get; set; }
        public string? Situacao { get; set; }
        public int? CargaHoraria { get; set; }
        public float? Nota { get; set; }
    }
}
