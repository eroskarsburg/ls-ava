using Application.Shared.Enum;

namespace WebApp.Shared.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
    }
}
