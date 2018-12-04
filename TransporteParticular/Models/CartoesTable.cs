using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class CartoesTable
    {
        public int IdCartoes { get; set; }
        public int IdCliente { get; set; }
        public string TipoCartao { get; set; }
        public string BandeiraCartao { get; set; }
        public decimal? NumeroCartao { get; set; }

        public ClienteTable IdClienteNavigation { get; set; }
    }
}
