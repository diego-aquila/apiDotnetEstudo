using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Pessoa
    {

       


        [Key]
        public Guid Id { set; get; }

        [Required(ErrorMessage = "Campo Nome é requerido")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Campo deve ter entre 3 e 200 caracteres")]
        public string Nome { set; get; }

        [StringLength(20, ErrorMessage = "Campo deve ter até 20 caracteres")]
        public string Telefone { set; get; }
        
        [EmailAddress]
        public string Email { set; get; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { set; get; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        [StringLength(20, ErrorMessage = "Campo gênero deve ter até 20 caracteres")]
        public string Genero { get; set; }

        public Guid? CidadeId { get; set; }


        public Pessoa()
        {
            Id = Guid.NewGuid();
        }

        //Relacionamento Entity Framework
        public Cidade Cidade { set; get; }

    }
}
