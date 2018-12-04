using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class DinheiroTable
    {
        public int IdDinheiro { get; set; }
        public int IdCliente { get; set; }
        public string TipoDinheiro { get; set; }

        public ClienteTable IdClienteNavigation { get; set; }
    }
}
