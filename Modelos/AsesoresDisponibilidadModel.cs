using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Citas.Administrador.Modelos
{
        [Table("AsesoresDisponibilidad")]
        public class AsesoresDisponibilidadModel
        {
            [Key]
            [Column("iddisponibilidad")]
            public int IdDisponibilidad { get; set; }

            [Column("tipodisponibilidad")]
            public int? TipoDisponibilidad { get; set; }

            [Column("desde")]
            public DateTime? Desde { get; set; }

            [Column("hasta")]
            public DateTime? Hasta { get; set; }

            [Column("idempresa")]
            public int? IdEmpresa { get; set; }

            [Column("idasesor")]
            public int? IdAsesor { get; set; }

            [Column("horainicial")]
            public int? HoraInicial { get; set; }

            [Column("minutoinicial")]
            public int? MinutoInicial { get; set; }

            [Column("horafinal")]
            public int? HoraFinal { get; set; }

            [Column("minutofinal")]
            public int? MinutoFinal { get; set; }

            [Column("lu")]
            public int? Lu { get; set; }

            [Column("ma")]
            public int? Ma { get; set; }

            [Column("mi")]
            public int? Mi { get; set; }

            [Column("ju")]
            public int? Ju { get; set; }

            [Column("vi")]
            public int? Vi { get; set; }

            [Column("sa")]
            public int? Sa { get; set; }

            [Column("do")]
            public int? Do { get; set; }

            [Column("establecimiento")]
            public int? Establecimiento { get; set; }
        }
    }


