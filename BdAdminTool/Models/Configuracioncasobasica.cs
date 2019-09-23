using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAdminbdTool.Models
{
    public partial class Configuracioncasobasica
    {
        public Configuracioncasobasica()
        {
            Detalleconfiguracioncasobasica = new HashSet<Detalleconfiguracioncasobasica>();
        }

        public int IdConfiguracionCasobasica { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha Caso")]
        public DateTime FechaInicial { get; set; }
        public int EtapaInicial { get; set; }
        public int EtapaFinal { get; set; }
        public string Descripcion { get; set; }

        public int IdTemporalidad { get; set; }

        public virtual Temporalidadesbasica IdTemporalidadNavigation { get; set; }
        public virtual ICollection<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
    }
}
