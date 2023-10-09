using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("TipoUsuario")]
    [Index(nameof(tipoUsuario), IsUnique = true)]
    public class TiposUsuario
    {
        //  Definindo que idTipoUsuario é a Chave Primaria.
        [Key]
        //  Gera o auto incremento.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Tipo de Usúario é obrigatorio o preenchimento!")]
        [StringLength(100,MinimumLength = 3, ErrorMessage = "Necessário o cmapo Tipo Usúario ter entre 3 e 100 caracteres!")]
        public string tipoUsuario { get; set; }
    }
}
