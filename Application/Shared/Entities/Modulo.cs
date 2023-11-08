namespace Application.Shared.Entities
{
    public class Modulo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? IdCurso { get; } = 0;
    }
}
