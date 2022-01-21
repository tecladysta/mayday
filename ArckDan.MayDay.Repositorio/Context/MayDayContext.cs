using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Domain.Models.Relacional;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Context
{
    public class MayDayContext : DbContext
    {
        #region atributos

        readonly IConfiguration _configuration;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe MayDayContext
        /// </summary>
        public MayDayContext() { }

        /// <summary>
        /// construtor da classe MayDayContext
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        public MayDayContext(IConfiguration configuration)
        {
            // bloco de construção de objetos
            _configuration = configuration;
        }

        #endregion

        #region métodos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=ArckDan.MayDay.Dev;User ID=sa;Password=LbfE@2704*");
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MayDayDev"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tabela de relacionamento entre campos e perfis
            modelBuilder.Entity<CampoPerfilModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
                    entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");
                    entity.ToTable("TB_MAYDAY_CAMPO_PERFIL");
                }
            );

            // tabela de credenciais do jwt
            modelBuilder.Entity<TokenModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.UserId).HasColumnName("USER_ID");
                    entity.Property(e => e.Senha).HasColumnName("SENHA");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_TOKEN");
                }
            );

            // tabela de login
            modelBuilder.Entity<LoginModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.UserId).HasColumnName("USER_ID");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_LOGIN")
                        .HasMany(p => p.Senha)
                        .WithOne()
                        .HasForeignKey(k => k.IdLogin)
                        .OnDelete(DeleteBehavior.NoAction);
                }
            );

            // tabela de campos
            modelBuilder.Entity<CampoModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.NomeTecnico).HasColumnName("NOME_TECNICO");
                    entity.Property(e => e.Tipo).HasColumnName("TIPO");
                    entity.Property(e => e.Tamanho).HasColumnName("TAMANHO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_CAMPO")
                        .HasMany(p => p.Campo)
                        .WithOne()
                        .HasForeignKey(p => p.IdCampo)
                        .OnDelete(DeleteBehavior.NoAction);
                }
            );

            // tabela de perfis
            modelBuilder.Entity<PerfilModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_PERFIL")
                        .HasMany(p => p.Perfil)
                        .WithOne()
                        .HasForeignKey(p => p.IdPerfil)
                        .OnDelete(DeleteBehavior.NoAction);
                    entity.ToTable("TB_MAYDAY_PERFIL")
                        .HasMany(p => p.Usuario)
                        .WithOne()
                        .HasForeignKey(p => p.IdPerfil)
                        .OnDelete(DeleteBehavior.NoAction);
                }
            );

            // tabela de usuários
            modelBuilder.Entity<UsuarioModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
                    entity.Property(e => e.Nome).HasColumnName("NOME");
                    entity.Property(e => e.CPF).HasColumnName("CPF");
                    entity.Property(e => e.Nascimento).HasColumnName("DATA_NASCIMENTO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_USUARIO")
                        .HasMany(p => p.Endereco)
                        .WithOne()
                        .HasForeignKey(p => p.IdUsuario)
                        .OnDelete(DeleteBehavior.NoAction);
                }
            );

            // tabela de senhas
            modelBuilder.Entity<SenhaModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");
                    entity.Property(e => e.Chave).HasColumnName("CHAVE");
                    entity.Property(e => e.Expiracao).HasColumnName("EXPIRACAO");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_SENHA");
                }
            );

            // tabela de endereços
            modelBuilder.Entity<EnderecoModel>(
                entity =>
                {
                    entity.Property(e => e.Id).HasColumnName("ID");
                    entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
                    entity.Property(e => e.CEP).HasColumnName("CEP");
                    entity.Property(e => e.Logradouro).HasColumnName("LOGRADOURO");
                    entity.Property(e => e.Numero).HasColumnName("NUMERO");
                    entity.Property(e => e.Complemento).HasColumnName("COMPLEMENTO");
                    entity.Property(e => e.Bairro).HasColumnName("BAIRRO");
                    entity.Property(e => e.Cidade).HasColumnName("CIDADE");
                    entity.Property(e => e.UF).HasColumnName("UF");
                    entity.Property(e => e.Inclusao).HasColumnName("DATA_INCLUSAO");
                    entity.Property(e => e.Alteracao).HasColumnName("DATA_ALTERACAO");
                    entity.ToTable("TB_MAYDAY_ENDERECO");
                }
            );
        }

        #endregion

        #region tabelas

        public DbSet<PerfilModel> TB_MAYDAY_PERFIL { get; set; }
        public DbSet<LoginModel> TB_MAYDAY_LOGIN { get; set; }
        public DbSet<TokenModel> TB_MAYDAY_TOKEN { get; set; }
        public DbSet<CampoModel> TB_MAYDAY_CAMPO { get; set; }
        public DbSet<CampoPerfilModel> TB_MAYDAY_CAMPO_PERFIL { get; set; }
        public DbSet<UsuarioModel> TB_MAYDAY_USUARIO { get; set; }
        public DbSet<SenhaModel> TB_MAYDAY_SENHA { get; set; }
        public DbSet<EnderecoModel> TB_MAYDAY_ENDERECO { get; set; }

        #endregion
    }
}