using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class ViagemTable
    {
        public ViagemTable()
        {
            ViagemRotaTable = new HashSet<ViagemRotaTable>();
        }

        public int IdViagem { get; set; }
        public int IdMotorista { get; set; }
        public int IdCliente { get; set; }
        public string EnderecoSaida { get; set; }
        public string EnderecoChegada { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public ClienteTable IdClienteNavigation { get; set; }
        public MotoristaTable IdMotoristaNavigation { get; set; }
        public ICollection<ViagemRotaTable> ViagemRotaTable { get; set; }
    }
}
