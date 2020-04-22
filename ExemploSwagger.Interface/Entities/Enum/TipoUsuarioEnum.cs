using System.ComponentModel;

namespace ExemploSwagger.Interface.Entities.Enum
{
    public enum TipoUsuarioEnum
    {
        [Description("Representa Usuário do Tipo Pessoa FÍSICA")]
        PessoaFisica = 1,

        [Description("Representa Usuário do Tipo Pessoa JURÍDICA")]
        PessoaJuridica = 2
    }
}