using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAdminbdTool.Models
{
    public partial class Valoresvariables
    {
        public int IdValorVariable { get; set; }
        public int IdTipoVariable { get; set; }
        public int IdVariable { get; set; }
        public float Valor { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime Fecha { get; set; }
        public int Periodo { get; set; }
        public int IdTemporalidad { get; set; }
        public int Idunidad { get; set; }
        public int IdObjetoSistema { get; set; }
        public int IdTipoObjeto { get; set; }
        public string Fuente { get; set; }
        public string TipoDia { get; set; }

        public string Version { get; set; }

        [Display(Name = "Objeto")]
        public virtual Objetossistemabasica IdObjetoSistemaNavigation { get; set; }

        [Display(Name = "Temporalidad")]
        public virtual Temporalidadesbasica IdTemporalidadNavigation { get; set; }

        [Display(Name = "Tipo Objeto")]
        public virtual Tiposobjetosbasica IdTipoObjetoNavigation { get; set; }

        [Display(Name = "Tipo Vble")]
        public virtual Tipovariables IdTipoVariableNavigation { get; set; }

        [Display(Name = "Variable")]
        public virtual Variables IdVariableNavigation { get; set; }

        [Display(Name = "Unidad")]
        public virtual Unidadesbasica IdunidadNavigation { get; set; }
    }
}
