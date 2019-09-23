using System;
using System.Collections.Generic;

namespace WebAdminbdTool.Models
{
    public partial class Costoscombustiblesbasica
    {
        public int Idcostoscombustibles { get; set; }
        public DateTime Fecha { get; set; }
        public string Ramal { get; set; }
        public string Recurso { get; set; }
        public double Valorcostocombustible { get; set; }
        public string Centroscombustible { get; set; }
    }
}
