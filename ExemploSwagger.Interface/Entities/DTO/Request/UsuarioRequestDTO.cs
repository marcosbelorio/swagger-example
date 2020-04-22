namespace ExemploSwagger.Interface.Entities.DTO.Request
{
    /// Mais exemplos em https://mattfrear.com/tag/swagger/
    public class UsuarioRequestDTO
    {
        /// <summary>Nome Completo do usuário</summary> 
        /// <example>José da Silva</example>
        public string Nome { get; set; }

        /// <summary>Login (username) do Usuário para autenticação no sistema</summary>         
        /// <example>zesilva</example>
        public string Login { get; set; }

        /// <summary> Representa o Tipo de Pessoa do Usuário</summary> 
        /// <remarks>
        ///     1 - Pessoa Física
        ///     2 - Pessoa Jurídica
        /// </remarks>       
        /// <example>1</example>
        public int TipoUsuario { get; set; }
    }
}
