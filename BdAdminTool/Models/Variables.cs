using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAdminbdTool.Models
{
    public partial class Variables
    {
        public Variables()
        {
            Detalleconfiguracioncasobasica = new HashSet<Detalleconfiguracioncasobasica>();
            Tipovariables = new HashSet<Tipovariables>();
            Valoresvariables = new HashSet<Valoresvariables>();
        }

        public int IdVariable { get; set; }
        public string NombreVariable { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Fecha Inicial")]
        public DateTime FechaInicial { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Fecha Final")]
        public DateTime? FechaFinal { get; set; }

        public virtual ICollection<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
        public virtual ICollection<Tipovariables> Tipovariables { get; set; }
        public virtual ICollection<Valoresvariables> Valoresvariables { get; set; }
    }
}
