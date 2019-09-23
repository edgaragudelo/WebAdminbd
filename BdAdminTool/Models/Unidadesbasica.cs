using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Unidadesbasica
    {
        public Unidadesbasica()
        {
            Valoresvariables = new HashSet<Valoresvariables>();
        }

        public int IdUnidad { get; set; }
        public string NombreUnidad { get; set; }

        public virtual ICollection<Valoresvariables> Valoresvariables { get; set; }
    }
}
