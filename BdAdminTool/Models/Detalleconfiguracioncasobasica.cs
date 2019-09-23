using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAdminbdTool.Models
{
    public partial class Detalleconfiguracioncasobasica
    {
        public int Iddetalleconfiguracioncaso { get; set; }
        public int IdConfiguracionCasobasica { get; set; }
        public int IdTipoVariable { get; set; }
        public int IdVariable { get; set; }
        public int IdTemporalidad { get; set; }
        public int Idobjeto { get; set; }
        public int IdTipoObjeto { get; set; }
        public string TipoDia { get; set; }

        [Display(Name = "Caso")]
        public virtual Configuracioncasobasica IdConfiguracionCasobasicaNavigation { get; set; }

        [Display (Name="Temporalidad")]
        public virtual Temporalidadesbasica IdTemporalidadNavigation { get; set; }

        [Display(Name = "Tipo Objeto")]
        public virtual Tiposobjetosbasica IdTipoObjetoNavigation { get; set; }

        [Display(Name = "Tipo Vble")]
        public virtual Tipovariables IdTipoVariableNavigation { get; set; }

        [Display(Name = "Variable")]
        public virtual Variables IdVariableNavigation { get; set; }

        [Display(Name = "Objeto")]
        public virtual Objetossistemabasica IdobjetoNavigation { get; set; }
    }
}
