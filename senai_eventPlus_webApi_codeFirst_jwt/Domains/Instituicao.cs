using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("Instituicao")]
    [Index(nameof(cnpj), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idInstituicao { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O campo \"cnpj\" é obrigatorio!")]
        [StringLength(14,MinimumLength = 14, ErrorMessage = "O campo \"cnpj\" deve conter os 14 digitos sem exeções!")]
        public string cnpj { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O campo \"endereço\" é obrigatório!")]
        [StringLength(150,MinimumLength = 3, ErrorMessage = "O campo \"endereço\" deve conter entre 3 e 150 caracteres!")]
        public string endereco { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O campo \"razão social\" é obrigatório!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"razão social\" deve conter entre 3 e 150 caracteres!")]
        public string razaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O campo \"nome fantasia\" é obrigatório!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"nome fantasia\" deve conter entre 3 e 150 caracteres!")]
        public string nomeFantasia { get; set; }
    }
}
