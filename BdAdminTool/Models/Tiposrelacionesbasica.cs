using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Tiposrelacionesbasica
    {
        public Tiposrelacionesbasica()
        {
            Relacionesobjetosbasica = new HashSet<Relacionesobjetosbasica>();
        }

        public int IdTiporelacion { get; set; }
        public string NombreTipoRelacion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int IdTipoObjeto1 { get; set; }
        public string NombreTablaObjeto1 { get; set; }
        public int IdTipoObjeto2 { get; set; }
        public string NombreTablaObjeto2 { get; set; }

        public virtual Tiposobjetosbasica IdTipoObjeto1Navigation { get; set; }
        public virtual Tiposobjetosbasica IdTipoObjeto2Navigation { get; set; }
        public virtual ICollection<Relacionesobjetosbasica> Relacionesobjetosbasica { get; set; }
    }
}
