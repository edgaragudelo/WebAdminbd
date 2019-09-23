using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAdminbdTool.Models
{
    public partial class Tipovariables
    {
        public Tipovariables()
        {
            Detalleconfiguracioncasobasica = new HashSet<Detalleconfiguracioncasobasica>();
            Valoresvariables = new HashSet<Valoresvariables>();
        }

        public int IdTipoVariable { get; set; }
        public int IdVariable { get; set; }
        public string NombreTipoVariable { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicial")]

        
        public DateTime FechaInicial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Final")]
        public DateTime? FechaFinal { get; set; }

        public virtual Variables IdVariableNavigation { get; set; }
        public virtual ICollection<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
        public virtual ICollection<Valoresvariables> Valoresvariables { get; set; }
    }
}
