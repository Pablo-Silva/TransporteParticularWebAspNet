using System;
using System.Collections.Generic;

namespace TransporteParticular.Models
{
    public partial class ClienteTable
    {
        public ClienteTable()
        {
            CartoesTable = new HashSet<CartoesTable>();
            DinheiroTable = new HashSet<DinheiroTable>();
            ViagemTable = new HashSet<ViagemTable>();
        }

        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string NumeroCelular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string TipoDeficiencia { get; set; }

        public ICollection<CartoesTable> CartoesTable { get; set; }
        public ICollection<DinheiroTable> DinheiroTable { get; set; }
        public ICollection<ViagemTable> ViagemTable { get; set; }
    }
}
