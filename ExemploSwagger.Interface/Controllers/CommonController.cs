using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ExemploSwagger.Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerResponse(400, "Mensagem de erro de regra de negócio", typeof(string))]
    [SwaggerResponse(500, "Mensagem de erro inesperado contendo o id para consulta", typeof(string))]
    public class CommonController : ControllerBase
    {

    }
}