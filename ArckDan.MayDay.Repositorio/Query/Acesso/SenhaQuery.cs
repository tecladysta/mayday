using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Acesso
{
    public class SenhaQuery : Connection, IQuery<SenhaModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe SenhaQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>

        public SenhaQuery(IConfiguration configuration)
        {
            // bloco de construção de objetos
            _configuration = configuration;

            // abre a conexão com o banco de dados
            AbrirConexao();
        }

        #endregion

        #region métodos

        public IEnumerable<SenhaModel> GetAll() =>
            Conn.Query<SenhaModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN");

        public IEnumerable<SenhaModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Conn.Query<SenhaModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public SenhaModel GetById(int id) =>
            Conn.Query<SenhaModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)Conn.Query<SenhaModel>($"SELECT ID TB_MAYDAY_LOGIN { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe SenhaQuery
        /// </summary>
        ~SenhaQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}