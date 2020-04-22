using System;
using System.Linq;
using System.Net;
using ExemploSwagger.Interface.Entities.DTO.Request;
using ExemploSwagger.Interface.Entities.Enum;
using ExemploSwagger.Interface.Entities.Model;
using ExemploSwagger.Interface.Utils;
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
        [HttpPost]        
        [SwaggerResponse((int)HttpStatusCode.OK, "Id do usuário adicionado", typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage))]
        public IActionResult Post(UsuarioRequestDTO usuario)
        {
            //recebendo o header informado
            string chaveApi = Request.Headers["ChaveApi"];

            //simulando uma validação de negócio
            var tipoUsuario = Enum.GetValues(typeof(TipoUsuarioEnum)).Cast<TipoUsuarioEnum>().ToList().Select(e => (int)e).ToList();
            if (!tipoUsuario.Contains(usuario.TipoUsuario))
                return BadRequest( new ErrorMessage(ErrorsMessages.User_Invalid, HttpStatusCode.BadRequest.ToString()));

            Random rnd = new Random();

            //simulando a criação de um novo usuário
            var usuarioDB = new Usuario
            {
                Id = rnd.Next(1, 13),
                Nome = usuario.Nome,
                Login = usuario.Login,
                TipoUsuario = usuario.TipoUsuario
            };
            return Ok(usuarioDB.Id);
        }

        /// <summary>
        /// Recupera um Usuário da base de dados
        /// </summary>
        [HttpGet("{id}")]        
        [SwaggerResponse((int)HttpStatusCode.OK, "Id do usuário ", typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ErrorMessage))]
        public IActionResult Get(int? id)
        {
            if(id == null || id <= 0)    
                 return BadRequest( new ErrorMessage(ErrorsMessages.Item_Conflict, HttpStatusCode.BadRequest.ToString()));


            // simulando Usuário retornando da base
            var usuarioRetorno = new UsuarioResponseDTO
            {
                Id = id ?? 0,
                Nome = "Pedro da Silva",
                Login = "Psilva",
                TipoUsuario = (int)TipoUsuarioEnum.PessoaFisica
            };

            return Ok(usuarioRetorno);


        }

    }
}
