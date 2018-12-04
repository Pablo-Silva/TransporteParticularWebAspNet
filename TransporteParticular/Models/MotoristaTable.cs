using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class MotoristaTable
    {
        public MotoristaTable()
        {
            ViagemTable = new HashSet<ViagemTable>();
        }

        public int IdMotorista { get; set; }
        public int? IdVeiculo { get; set; }
        public int? IdDetalhesVeiculos { get; set; }
        public string NomeMotorista { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string NumeroCelular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string StatusMotorista { get; set; }
        public string CarteiraMotorista { get; set; }

        public DetalhesVeiculosTable IdDetalhesVeiculosNavigation { get; set; }
        public VeiculoTable IdVeiculoNavigation { get; set; }
        public ICollection<ViagemTable> ViagemTable { get; set; }
    }
}
