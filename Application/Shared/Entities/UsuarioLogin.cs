using Application.Shared.Enum;

namespace Application.Shared.Entities
{
    public class UsuarioLogin
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
    }
}
