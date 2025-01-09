using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Citas.Administrador.Modelos
{
    [Table("Asesores", Schema = "dbo")]
    public class AsesoresModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nombre")]
        [StringLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres.")]
        public string? Nombre { get; set; }

        [Column("especialidad")]
        public int? Especialidad { get; set; }

        [Column("establecimientos_id")]
        public int? EstablecimientosId { get; set; }

        [Column("empresa_id")]
        public int? EmpresaId { get; set; }
    }
}
