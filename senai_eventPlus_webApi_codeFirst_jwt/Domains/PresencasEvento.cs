using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("PresencasEvento")]
    public class PresencasEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idPresençasEvento { get; set; }

        [Required(ErrorMessage = "O campo \"id presenca evento\" é obrigatório!")]
        public Guid idUsuario { get; set; }

        [Required(ErrorMessage = "O campo \"id evento\" é obrigatório!")]
        public Guid idEvento { get; set; }

        [Column(TypeName = "BIT")]
        [DefaultValue(0)]
        public bool situacao { get; set; }

        [ForeignKey(nameof(idUsuario))]
        public Usuario usuario { get; set; }

        [ForeignKey(nameof(idEvento))]
        public Evento evento { get; set;}
    }
}
