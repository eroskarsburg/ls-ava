using System.ComponentModel;

namespace Application.Shared.Enum
{
    public enum NivelAcesso
    {
        [Description("Administrador")]
        Administrador = 0,
        [Description("Professor")]
        Professor = 1,
        [Description("Aluno")]
        Aluno = 2
    }
}
