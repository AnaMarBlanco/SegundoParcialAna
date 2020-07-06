using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoPacialAna.Entidades
{
    class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; }

        public List<TareasDetalle> Detalles = new List<TareasDetalle>();

        
    }
}
