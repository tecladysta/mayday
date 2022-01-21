using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Operacional
{
    public class EnderecoQuery : Connection, IQuery<EnderecoModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe EnderecoQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>

        public EnderecoQuery(IConfiguration configuration)
        {
            // bloco de construção de objetos
            _configuration = configuration;

            // abre a conexão com o banco de dados
            AbrirConexao();
        }

        #endregion

        #region métodos

        public IEnumerable<EnderecoModel> GetAll() =>
            Conn.Query<EnderecoModel>($"SELECT ID, NOME, DESCRICAO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_PERFIL");

        public IEnumerable<EnderecoModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Conn.Query<EnderecoModel>($"SELECT ID, NOME, DESCRICAO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_PERFIL { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public EnderecoModel GetById(int id) =>
            Conn.Query<EnderecoModel>($"SELECT ID, NOME, DESCRICAO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_PERFIL WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)Conn.Query<EnderecoModel>($"SELECT ID TB_MAYDAY_PERFIL { where }").FirstOrDefault().Id;

        #endregion

        #region destrutores

        /// <summary>
        /// destrutor da classe EnderecoQuery
        /// </summary>
        ~EnderecoQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}
