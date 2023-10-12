using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idComentario { get; set; }

        [Required(ErrorMessage = "O campo \"id usuario\" é obrigátorio!")]
        public Guid idUsuario { get; set; }

        [Required(ErrorMessage = "O campo \"id evento\" é obrigátorio!")]
        public Guid idEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O campo \"descrição\" é obrigatório!")]
        public string descricao { get; set; }

        [Column(TypeName = "BIT")]
        [DefaultValue(0)]
        public bool exibe { get; set; }

        [ForeignKey(nameof(idUsuario))]
        public Usuario usuario { get; set; }

        [ForeignKey(nameof(idEvento))]
        public Evento evento { get; set; }

    }
}
