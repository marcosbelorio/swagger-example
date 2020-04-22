namespace ExemploSwagger.Interface.Entities.DTO.Request
{
    public class UsuarioResponseDTO
    {
        /// <summary>Id do Usuário consultado</summary> 
        /// <example>150</example>
        public int Id { get; set; }


        /// <summary>Nome Completo do usuário da consulta</summary> 
        /// <example>José da Silva</example>
        public string Nome { get; set; }

        /// <summary>Login (username) do Usuário para autenticação no sistema</summary>         
        /// <example>zesilva</example>
        public string Login { get; set; }

        /// <summary> Representa o Tipo de Pessoa do Usuário</summary>
        /// <example>1</example>
        public int TipoUsuario { get; set; }
    }
}
