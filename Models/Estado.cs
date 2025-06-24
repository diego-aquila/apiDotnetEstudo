using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Estado
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage ="O Campo sigla deve ter 2 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Campo nome deve ter entre 3 e 60 caracteres")]
        public string Nome { get; set; }
    }
}
