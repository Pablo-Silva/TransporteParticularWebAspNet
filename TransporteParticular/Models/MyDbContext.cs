using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransporteParticular.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartoesTable> CartoesTable { get; set; }
        public virtual DbSet<ClienteTable> ClienteTable { get; set; }
        public virtual DbSet<DetalhesVeiculosTable> DetalhesVeiculosTable { get; set; }
        public virtual DbSet<DinheiroTable> DinheiroTable { get; set; }
        public virtual DbSet<MotoristaTable> MotoristaTable { get; set; }
        public virtual DbSet<VeiculoTable> VeiculoTable { get; set; }
        public virtual DbSet<ViagemRotaTable> ViagemRotaTable { get; set; }
        public virtual DbSet<ViagemTable> ViagemTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=transporteparticulartable");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartoesTable>(entity =>
            {
                entity.HasKey(e => e.IdCartoes);

                entity.ToTable("cartoes_table");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("ID_CLIENTE");

                entity.Property(e => e.IdCartoes)
                    .HasColumnName("ID_CARTOES")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BandeiraCartao)
                    .HasColumnName("BANDEIRA_CARTAO")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_CLIENTE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroCartao)
                    .HasColumnName("NUMERO_CARTAO")
                    .HasColumnType("decimal(25,0)");

                entity.Property(e => e.TipoCartao)
                    .HasColumnName("TIPO_CARTAO")
                    .HasColumnType("varchar(25)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CartoesTable)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cartoes_table_ibfk_1");
            });

            modelBuilder.Entity<ClienteTable>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("cliente_table");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_CLIENTE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("DATA_CADASTRO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasColumnName("NOME_CLIENTE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NumeroCelular)
                    .IsRequired()
                    .HasColumnName("NUMERO_CELULAR")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TipoDeficiencia)
                    .HasColumnName("TIPO_DEFICIENCIA")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DetalhesVeiculosTable>(entity =>
            {
                entity.HasKey(e => e.IdDetalhesVeiculos);

                entity.ToTable("detalhes_veiculos_table");

                entity.Property(e => e.IdDetalhesVeiculos)
                    .HasColumnName("ID_DETALHES_VEICULOS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcentosVeiculo)
                    .HasColumnName("ACENTOS_VEICULO")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.CorVeiculo)
                    .HasColumnName("COR_VEICULO")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.PlacaVeiculo)
                    .HasColumnName("PLACA_VEICULO")
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<DinheiroTable>(entity =>
            {
                entity.HasKey(e => e.IdDinheiro);

                entity.ToTable("dinheiro_table");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("ID_CLIENTE");

                entity.Property(e => e.IdDinheiro)
                    .HasColumnName("ID_DINHEIRO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_CLIENTE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoDinheiro)
                    .IsRequired()
                    .HasColumnName("TIPO_DINHEIRO")
                    .HasColumnType("varchar(25)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DinheiroTable)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dinheiro_table_ibfk_1");
            });

            modelBuilder.Entity<MotoristaTable>(entity =>
            {
                entity.HasKey(e => e.IdMotorista);

                entity.ToTable("motorista_table");

                entity.HasIndex(e => e.IdDetalhesVeiculos)
                    .HasName("ID_DETALHES_VEICULOS");

                entity.HasIndex(e => e.IdVeiculo)
                    .HasName("ID_VEICULO");

                entity.Property(e => e.IdMotorista)
                    .HasColumnName("ID_MOTORISTA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CarteiraMotorista)
                    .IsRequired()
                    .HasColumnName("CARTEIRA_MOTORISTA")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("DATA_CADASTRO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IdDetalhesVeiculos)
                    .HasColumnName("ID_DETALHES_VEICULOS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVeiculo)
                    .HasColumnName("ID_VEICULO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeMotorista)
                    .IsRequired()
                    .HasColumnName("NOME_MOTORISTA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NumeroCelular)
                    .IsRequired()
                    .HasColumnName("NUMERO_CELULAR")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasColumnType("char(1)");

                entity.Property(e => e.StatusMotorista)
                    .IsRequired()
                    .HasColumnName("STATUS_MOTORISTA")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdDetalhesVeiculosNavigation)
                    .WithMany(p => p.MotoristaTable)
                    .HasForeignKey(d => d.IdDetalhesVeiculos)
                    .HasConstraintName("motorista_table_ibfk_2");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.MotoristaTable)
                    .HasForeignKey(d => d.IdVeiculo)
                    .HasConstraintName("motorista_table_ibfk_1");
            });

            modelBuilder.Entity<VeiculoTable>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo);

                entity.ToTable("veiculo_table");

                entity.Property(e => e.IdVeiculo)
                    .HasColumnName("ID_VEICULO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataFabricacao)
                    .HasColumnName("DATA_FABRICACAO")
                    .HasColumnType("date");

                entity.Property(e => e.MarcaVeiculo)
                    .HasColumnName("MARCA_VEICULO")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.ModeloVeiculo)
                    .HasColumnName("MODELO_VEICULO")
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<ViagemRotaTable>(entity =>
            {
                entity.HasKey(e => e.IdViagemRota);

                entity.ToTable("viagem_rota_table");

                entity.HasIndex(e => e.IdViagem)
                    .HasName("ID_VIAGEM");

                entity.Property(e => e.IdViagemRota)
                    .HasColumnName("ID_VIAGEM_ROTA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdViagem)
                    .HasColumnName("ID_VIAGEM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latidute)
                    .HasColumnName("LATIDUTE")
                    .HasColumnType("decimal(10,8)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasColumnType("decimal(11,8)");

                entity.HasOne(d => d.IdViagemNavigation)
                    .WithMany(p => p.ViagemRotaTable)
                    .HasForeignKey(d => d.IdViagem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("viagem_rota_table_ibfk_1");
            });

            modelBuilder.Entity<ViagemTable>(entity =>
            {
                entity.HasKey(e => e.IdViagem);

                entity.ToTable("viagem_table");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("ID_CLIENTE");

                entity.HasIndex(e => e.IdMotorista)
                    .HasName("ID_MOTORISTA");

                entity.Property(e => e.IdViagem)
                    .HasColumnName("ID_VIAGEM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataFim)
                    .HasColumnName("DATA_FIM")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("DATA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.EnderecoChegada)
                    .IsRequired()
                    .HasColumnName("ENDERECO_CHEGADA")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EnderecoSaida)
                    .IsRequired()
                    .HasColumnName("ENDERECO_SAIDA")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_CLIENTE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMotorista)
                    .HasColumnName("ID_MOTORISTA")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ViagemTable)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("viagem_table_ibfk_2");

                entity.HasOne(d => d.IdMotoristaNavigation)
                    .WithMany(p => p.ViagemTable)
                    .HasForeignKey(d => d.IdMotorista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("viagem_table_ibfk_1");
            });
        }
    }
}
