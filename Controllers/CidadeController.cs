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
                List<CidadeDTO> result = _context.Cidade
                    .Include(item => item.Estado)
                    .Select(r => new CidadeDTO 
                    { Nome = r.Nome, Estado = 
                    new EstadoDTO 
                    { Nome = r.Estado.Nome, Sigla = r.Estado.Sigla } })
                    .ToList(); return Ok(result);
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
    }
}
