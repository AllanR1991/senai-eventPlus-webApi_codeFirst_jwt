using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idEvento { get; set; }

        [Required(ErrorMessage = "O campo \"id instituicao\" é obrigatorio!")]
        public Guid idInstituicao { get; set; }

        [Required(ErrorMessage = "O campo \"id tipo evento\" é obrigatorio!")]
        public Guid idTipoEvento { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O campo \"nome evento\" é obrigatorio!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"Nome Evento\" deve conter entre 3 a 150 caracteres!")]
        public string nomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O campo \"descrição\" é obrigatorio!")]     
        public string descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "O campo \"data do evento\" é obrigatorio!")]        
        public DateTime dataEvento { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O campo \"hora do evento\" é obrigatorio!")]
        public TimeSpan horarioEvento { get; set; }

        [ForeignKey(nameof(idInstituicao))]
        public Instituicao instituicao { get; set; }

        [ForeignKey(nameof (idTipoEvento))]
        public TiposEvento tipoEvento { get; set; }
    }
}
