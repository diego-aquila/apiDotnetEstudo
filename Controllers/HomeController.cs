using Microsoft.AspNetCore.Mvc;
using WebApplication1.dtos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            string result = "Retorno em texto";
            return Ok(result);
        }

        [HttpGet("api/info2")]
        public IActionResult GetInfo2()
        {
            string result = "Retorno info 2";
            return Ok(result);
        }
        
        [HttpGet("api/info3/{id}")]
        public IActionResult GetInfo3([FromRoute] int id)
        {
            string result = $"Foi passado o parametro {id}";
            return Ok(result);
        }

        [HttpPost("api/info4")]
        public IActionResult GetInfo4([FromQuery] string name)
        {
            string result = $"Foi passado o parametro {name}";
            return Ok(result);
        }

        [HttpPost("api/info5")]
        public IActionResult GetInfo5([FromBody] Corpo corpo)
        {
            string result = $"Foi passado o parametro {corpo.Nome} e {corpo.Idade} e {string.Join(", ", corpo.Sobrenomes)}";

            if (corpo.Idade is null)
            {
                return BadRequest(new { 
                erro = true,
                message = "Idade não pode ser Nulo"
                });
            }

            return Ok(new
            {

                nome = corpo.Nome,
                idade = corpo.Idade,
                sobrenomes = corpo.Sobrenomes

            });
        }
    }
}
