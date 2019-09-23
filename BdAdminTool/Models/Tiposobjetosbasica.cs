using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Tiposobjetosbasica
    {
        public Tiposobjetosbasica()
        {
            Detalleconfiguracioncasobasica = new HashSet<Detalleconfiguracioncasobasica>();
            Objetossistemabasica = new HashSet<Objetossistemabasica>();
            TiposrelacionesbasicaIdTipoObjeto1Navigation = new HashSet<Tiposrelacionesbasica>();
            TiposrelacionesbasicaIdTipoObjeto2Navigation = new HashSet<Tiposrelacionesbasica>();
            Valoresvariables = new HashSet<Valoresvariables>();
        }

        public int IdTipoObjeto { get; set; }
        public string NombreTipoObjeto { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string NombreTabla { get; set; }

        public virtual ICollection<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
        public virtual ICollection<Objetossistemabasica> Objetossistemabasica { get; set; }
        public virtual ICollection<Tiposrelacionesbasica> TiposrelacionesbasicaIdTipoObjeto1Navigation { get; set; }
        public virtual ICollection<Tiposrelacionesbasica> TiposrelacionesbasicaIdTipoObjeto2Navigation { get; set; }
        public virtual ICollection<Valoresvariables> Valoresvariables { get; set; }
    }
}
