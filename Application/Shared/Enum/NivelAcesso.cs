using System.ComponentModel;

namespace Application.Shared.Enum
{
    internal enum NivelAcesso
    {
        [Description("Administrador")]
        Administrador = 0,
        [Description("Coordenador")]
        Coordenador = 1,
        [Description("Aluno")]
        Aluno = 2
    }
}
