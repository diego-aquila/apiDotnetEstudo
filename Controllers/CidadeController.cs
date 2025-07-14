using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Data;
using WebApplication1.dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : Controller
    {
        private readonly ProjectDbContext _context;

        public CidadeController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCidades()
        {
            try
            {
                List<Cidade> result = _context.Cidade
                    
                    .ToList(); 
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar cidades: {e.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateCidade([FromBody] Cidade cidade)
        {
            try
            {
                _context.Cidade.Add(cidade);
               int retorno = _context.SaveChanges();

                if (retorno == 1)
                {
                    return Ok($"Cidade {cidade.Nome} incluida com sucesso");
                }
                return BadRequest("Erro ao inserir a cidade");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao inserir a cidade: {e.Message}");
            }
        }


        [HttpPut]
        public IActionResult UpdateCidade([FromBody] Cidade cidade)
        {
            try
            {
                _context.Cidade.Update(cidade);
                int retorno = _context.SaveChanges();

                if (retorno == 1)
                {
                    return Ok($"Cidade {cidade.Nome} atualizada com sucesso");
                }
                return BadRequest("Erro ao atualizar a cidade");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao atualizar a cidade: {e.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCidade([FromRoute] Guid id)
        {
            try
            {
                Cidade cidade = _context.Cidade.Find(id);

                if (cidade != null)
                {
                    _context.Cidade.Remove(cidade);
                    int retorno = _context.SaveChanges();
                    if (retorno == 1)
                    {
                        return Ok(new
                        {
                            success = true,
                            message = "Cidade excluída com sucesso"
                        });
                    }
                    return BadRequest("Erro ao deletar a cidade");
                }

                return NotFound(new
                {
                    success = false,
                    message = "Cidade não encontrada"
                }

                );         

                
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao excluir a cidade: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getCidadeById([FromRoute] Guid id)
        {
            try
            {
                Cidade cidade = _context.Cidade.Find(id);

                if (cidade != null)
                {
                   
                        return Ok(new { nome = cidade.Nome, estado = cidade.EstadoSigla });
                }
                

                return NotFound(new
                {
                    success = false,
                    message = "Cidade não encontrada"
                }

                );


            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao pesquisar a cidade: {e.Message}");
            }
        }

        [HttpGet("Pesquisa")]
        public IActionResult GetCidadePesquisa([FromQuery] string valor)
        {
            try
            {
                List<CidadeDTO> lista = (from cidade in _context.Cidade
                            where cidade.Nome.ToUpper().Contains(valor.ToUpper())
                            || cidade.EstadoSigla.ToUpper().Contains(valor.ToUpper())
                            select new CidadeDTO { 
                                Nome = cidade.Nome, 
                                Estado = new EstadoDTO { 
                                    Sigla = cidade.Estado.Sigla, 
                                    Nome = cidade.Estado.Nome } 
                            }).ToList();

                if (lista.Any())
                {
                    return Ok(lista);
                }

                return NotFound(new 
                {
                    success = false,
                    message = $"A busca por '{valor}' não retornou nenhum resultado"
                }
                );

            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar cidades: {e.Message}");
            }


        }
    }
}
