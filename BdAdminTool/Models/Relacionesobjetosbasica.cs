using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Relacionesobjetosbasica
    {
        public int IdTiporelacion { get; set; }
        public int Idrelacion { get; set; }
        public int IdObjeto1 { get; set; }
        public int IdObjeto2 { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual Tiposrelacionesbasica IdTiporelacionNavigation { get; set; }
    }
}
