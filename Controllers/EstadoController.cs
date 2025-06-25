using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : Controller
    {
        private readonly ProjectDbContext _context;

        public EstadoController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEstados()
        {
            try {
                List<Estado> result = _context.Estado.ToList();
                return Ok(result);

            }
            catch(Exception e) {
                return BadRequest($"Erro ao buscar estados: {e.Message}");
            } 
            
            
        }

        [HttpPost]
        public IActionResult CreateEstado([FromBody] Estado estado)
        {
            try
            {
                EntityEntry<Estado> estadoInserido = _context.Estado.Add(estado);
                int insercao = _context.SaveChanges();

                if (insercao == 1)
                {
                    return Ok("Estado incluido com sucesso");
                }

                return BadRequest("Estado nao foi incluido");

            }
            catch (Exception e)
            {
                return BadRequest($"Estado não incluído: {e.Message}");
            }


        }

        [HttpPut]
        public IActionResult UpdateEstado([FromBody] Estado estado)
        {
            try
            {
                _context.Estado.Update(estado);
                int atualizacao = _context.SaveChanges();

                if (atualizacao == 1)
                {
                    return Ok("Estado atualizado com sucesso");
                }

                return BadRequest("Estado nao foi atualizado");

            }
            catch (Exception e)
            {
                return BadRequest($"Estado não atualizado: {e.Message}");
            }


        }

        [HttpDelete("{sigla}")]
        public IActionResult DeleteEstado([FromRoute] string sigla)
        {
            try
            {
                Estado? estado = _context.Estado.Find(sigla);

                if (estado?.Sigla == sigla && !string.IsNullOrEmpty(estado.Sigla))
                {
                    _context.Estado.Remove(estado);
                    int delete = _context.SaveChanges();

                    if (delete == 1)
                    {
                        return Ok("Estado excluido com sucesso");
                    }

                }

                             

                return BadRequest("Estado nao foi excluído");

            }
            catch (Exception e)
            {
                return BadRequest($"Estado nao foi excluído: {e.Message}");
            }


        }
    }
}
