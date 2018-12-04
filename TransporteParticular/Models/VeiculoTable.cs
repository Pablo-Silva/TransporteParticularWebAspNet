using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class VeiculoTable
    {
        public VeiculoTable()
        {
            MotoristaTable = new HashSet<MotoristaTable>();
        }

        public int IdVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string MarcaVeiculo { get; set; }
        public DateTime? DataFabricacao { get; set; }

        public ICollection<MotoristaTable> MotoristaTable { get; set; }
    }
}
