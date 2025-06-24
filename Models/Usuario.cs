using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { set; get; }


        [Required(ErrorMessage = "Campo Nome é requerido")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Campo deve ter entre 3 e 200 caracteres")]
        public string Nome { set; get; }

        [Required(ErrorMessage = "Campo Login é requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Campo deve ter entre 3 e 20 caracteres")]
        public string Login { set; get; }


        [Required(ErrorMessage = "Campo Senha é requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Campo deve ter entre 3 e 20 caracteres")]
        public string Password { set; get; }


        [Required(ErrorMessage = "Campo Função é requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Campo deve ter entre 3 e 20 caracteres")]
        public string Funcao { set; get; }



    }
}
