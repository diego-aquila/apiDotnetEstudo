using WebApplication1.Models;

namespace WebApplication1.dtos
{
    public class CidadeDTO
    {
        public string Nome { get; set; }
        public EstadoDTO Estado
        {
            get; set;
        }
    }
}
