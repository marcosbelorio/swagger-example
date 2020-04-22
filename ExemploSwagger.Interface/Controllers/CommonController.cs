using System.Net;
using ExemploSwagger.Interface.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ExemploSwagger.Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Mensagem de erro de regra de negócio", typeof(ErrorMessage))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Mensagem de erro de exceção não tratada pela aplicação", typeof(ErrorMessage))]
    public class CommonController : ControllerBase
    {

    }
}