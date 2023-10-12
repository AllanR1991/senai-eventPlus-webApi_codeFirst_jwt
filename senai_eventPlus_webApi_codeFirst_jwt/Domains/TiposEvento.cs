using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("TiposEvento")]
    [Index(nameof(tipoEvento), IsUnique = true )]
    public class TiposEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idTiposEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O campo \"tipo evento\" é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"tipo evento\" deve conter entre 3 e 100 caracteres!")]
        public string tipoEvento { get; set; }
    }
}
