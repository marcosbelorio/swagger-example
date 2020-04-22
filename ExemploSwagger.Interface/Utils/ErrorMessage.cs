using System.ComponentModel;
using EnumsNET;

namespace ExemploSwagger.Interface.Utils
{
    public class ErrorMessage
    {
        public ErrorMessage(ErrorsMessages enumError, string code, string message = "")
        {
            Code = code;
            Message = $"{message} - {((ErrorsMessages)enumError).AsString(EnumFormat.Description)}";
        }
        
        
        /// <summary>Código do Erro, Pode ser retornado algum código de erro customizado</summary> 
        /// <example>ERR-0001</example>
        public string Code { get; set; }
        
        /// <summary>Mensagem detalhada do Erro</summary> 
        /// <example>Tipo de Usuário inválido.</example>
        public string Message { get; set; }
    }

    /// <summary>
    ///     Aqui  Mensagens padrão de erro, seria interessante qeu cada entidade do domínio implementasse seu próprio Enum de Error MEssages
    /// </summary>
    public enum ErrorsMessages
    {
        [Description("Erro Fatal. Contate o Administrator. Mais detalhes no log.")]
        Fatal_Error = 0,

        [Description("Nenhum item encontrado.")]
        Item_Not_Found = 1,

        [Description("Item Consultado Foi Apagado Recentemente.")]
        Item_Gone = 2,

        [Description("Conflito na Consulta. Erro nos dados de entrada.")]
        Item_Conflict = 3,

        [Description("Tipo Usuário informado não é válido.")]
        User_Invalid = 4
    }
}
