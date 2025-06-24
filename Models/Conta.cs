using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Conta
    {
        [Key]
        public Guid Id { set; get; }

        [Required(ErrorMessage ="Campo Descrição é obrigatório")]
        [StringLength(200, ErrorMessage ="O campo só permite até 200 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo data de vencimento é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? DataVencimento { set; get; }

        [DataType(DataType.Date)]
        public DateTime? DataPagamento { set; get; }


        [Required(ErrorMessage = "Campo situação é obrigatório")]
        public Situacao Situacao { get; set; }

        [Required(ErrorMessage = "Campo situação é obrigatório")]
        public Guid PessoaId { get; set; }

        public Conta()
        {
            Id = Guid.NewGuid();
        }

        public Pessoa Pessoa { get; set; }

    }
}
