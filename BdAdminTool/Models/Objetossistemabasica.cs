using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Objetossistemabasica
    {
        public Objetossistemabasica()
        {
            Detalleconfiguracioncasobasica = new HashSet<Detalleconfiguracioncasobasica>();
            Valoresvariables = new HashSet<Valoresvariables>();
        }

        public int IdobjetoSistema { get; set; }
        public int IdTipoObjeto { get; set; }
        public string NombreObjeto { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual Tiposobjetosbasica IdTipoObjetoNavigation { get; set; }
        public virtual ICollection<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
        public virtual ICollection<Valoresvariables> Valoresvariables { get; set; }
    }
}
