using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class ViagemRotaTable
    {
        public int IdViagemRota { get; set; }
        public int IdViagem { get; set; }
        public decimal Latidute { get; set; }
        public decimal Longitude { get; set; }

        public ViagemTable IdViagemNavigation { get; set; }
    }
}
