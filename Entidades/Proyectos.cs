using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegundoPacialAna.Entidades
{
    class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public int TiempoTotal { get; set; }

        [ForeignKey("ProyectoId")]
        public List<TareasDetalle> Detalles { get; set; } = new List<TareasDetalle>();

        
    }
}
