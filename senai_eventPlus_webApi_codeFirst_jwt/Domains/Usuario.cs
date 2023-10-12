using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("Usuario")]
    [Index( nameof(email), IsUnique = true )]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idUsuario { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required]
        [StringLength(150,MinimumLength = 3, ErrorMessage = "O campo nome deve conter ente 3 e 150 caracteres!")]
        public string nome { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo email deve conter ente 3 e 150 caracteres!")]
        public string email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo email deve conter ente 3 e 100 caracteres!")]
        public string senha { get; set; }


        [Required(ErrorMessage = "É necessário informar o tipo de usuario!")]
        public Guid idTipoUsuario { get; set; }

        //  Define a chave estrangeira
        [ForeignKey("idTipoUsuario")]
        public TiposUsuario tiposUsuario { get; set; }
    }
}
