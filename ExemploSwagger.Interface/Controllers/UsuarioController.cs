using System;
using System.Linq;
using ExemploSwagger.Interface.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ExemploSwagger.Interface.Controllers
{
    public class UsuarioController : CommonController
    {
        public UsuarioController()
        {
        }

        /// <summary>
        /// Adiciona um Usuário
        /// </summary>
        /// <remarks>
        /// Exemplo de chamada:
        /// 
        ///     POST usuario
        ///     {        
        ///       "Nome": "Marcos Belorio",
        ///       "Login": "marcos",
        ///       "TipoUsuario": 1        
        ///     }
        ///
        /// TipoUsuario:
        ///
        ///     1 - Pessoa Física
        ///     2 - Pessoa Jurídica
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(200, "Id do usuário adicionado", typeof(int))]
        public IActionResult Post(UsuarioEntity usuario)
        {
            //recebendo o header informado
            string chaveApi = Request.Headers["ChaveApi"];

            //simulando uma validação de negócio
            var tipoUsuario = Enum.GetValues(typeof(TipoUsuario)).Cast<TipoUsuario>().ToList().Select(e => (int)e).ToList();
            if (!tipoUsuario.Contains(usuario.TipoUsuario))
                return BadRequest("Tipo Usuário informado não é válido.");

            //simulando a criação de um novo usuário
            var usuarioDB = new UsuarioEntity
            {
                Id = 1,
                Nome = usuario.Nome,
                Login = usuario.Login,
                TipoUsuario = usuario.TipoUsuario
            };
            return Ok(usuarioDB.Id);
        }
    }
}
