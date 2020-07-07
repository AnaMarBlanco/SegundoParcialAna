using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoPacialAna.Entidades
{
    class TareasDetalle
    {
        [Key]
        public int TareaId { get; set; }
        public string Requerimientos { get; set; }
        public int Tiempo { get; set; }
        public int  TipoId{ get; set; }
        public string TipoTarea { get; set; }

        public TareasDetalle(int tareaId, string requerimientos, int tiempo, int tipoId, string tipoTarea)
        {
            TareaId = tareaId;
            Requerimientos = requerimientos;
            Tiempo = tiempo;
            TipoId = tipoId;
            TipoTarea = tipoTarea;
        }

        public TareasDetalle()
        {
            TareaId = 0;
            Requerimientos = String.Empty;
            Tiempo = 0;
            TipoId = 0;
            TipoTarea = String.Empty;
        }
    }
}
