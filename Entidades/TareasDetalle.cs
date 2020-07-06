using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoPacialAna.Entidades
{
    class TareasDetalle
    {
        [Key]

        public int TareaDetalleId { get; set; }
        public string Requerimientos { get; set; }
        public int Tiempo { get; set; }
        public int  TipoId{ get; set; }
        public string TipoTareas { get; set; }

    }
}
