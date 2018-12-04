using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class DetalhesVeiculosTable
    {
        public DetalhesVeiculosTable()
        {
            MotoristaTable = new HashSet<MotoristaTable>();
        }

        public int IdDetalhesVeiculos { get; set; }
        public string PlacaVeiculo { get; set; }
        public string CorVeiculo { get; set; }
        public decimal? AcentosVeiculo { get; set; }

        public ICollection<MotoristaTable> MotoristaTable { get; set; }
    }
}
