using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Temporalidadesbasica
    {
        public Temporalidadesbasica()
        {
            Detalleconfiguracioncasobasica = new HashSet<Detalleconfiguracioncasobasica>();
            //Configuracioncasobasica = new HashSet<Configuracioncasobasica>();
            Valoresvariables = new HashSet<Valoresvariables>();
        }

        public int Idtemporalidad { get; set; }
        public string NombreTemporalidad { get; set; }

        public virtual ICollection<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
        public virtual ICollection<Valoresvariables> Valoresvariables { get; set; }

    }
}
