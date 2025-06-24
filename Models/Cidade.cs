using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Cidade
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Campo Nome é requerido")]
        [StringLength(200, MinimumLength =3, ErrorMessage ="Campo deve ter entre 3 e 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo estado é obrigatório")]
        [StringLength(2, MinimumLength =2, ErrorMessage ="O campo sigla deve ter pelo menos dois caracteres")]
        public string EstadoSigla { get; set; }


        public Cidade() {

            Id = Guid.NewGuid();
        
        }

        //Relacionamento Entity Framework
        public Estado Estado { get; set; }
    }
}
