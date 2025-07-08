using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
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

        [HttpGet("{sigla}")]
        public IActionResult GetEstadoBySigla([FromRoute] string sigla)
        {
            try
            {
                Estado? result = _context.Estado.Find(sigla.ToUpper());

                if (result is Estado)
                {
                return Ok(result);
                    
                }

                return NotFound($"O estado {sigla} não foi encontrado");

            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar estados: {e.Message}");
            }


        }

        [HttpGet("Pesquisa")]
        public IActionResult GetEstadoPesquisa([FromQuery] string valor)
        {
            try
            {
                var lista = from o in _context.Estado.ToList()
                            where o.Sigla.ToUpper().Contains(valor.ToUpper()) 
                            || o.Nome.ToUpper().Contains(valor.ToUpper())
                            select o;

                if (lista.Any())
                {
                    return Ok(lista);
                }

                return NotFound("Sua busca não houve retorno");

            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar estados: {e.Message}");
            }


        }

        [HttpGet("Paginacao")]
        public IActionResult GetEstadoPaginacao([FromQuery] string valor, int skip, int take, bool ordemDesc)
        {
            try
            {
                var lista = from o in _context.Estado.ToList()
                            where o.Sigla.ToUpper().Contains(valor.ToUpper())
                            || o.Nome.ToUpper().Contains(valor.ToUpper())
                            select o;

                if (lista.Any())
                {
                    return Ok(lista);
                }

                return NotFound("Sua busca não houve retorno");

            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar estados: {e.Message}");
            }


        }

        [HttpPost]
        public IActionResult CreateEstado([FromBody] Estado estado)
        {
            try
            {
                estado.Sigla = estado.Sigla.ToUpper();

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
