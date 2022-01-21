using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Acesso
{
    public class TokenQuery : Connection, IQuery<TokenModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe TokenQuery
        /// </summary>
        public TokenQuery(IConfiguration configuration)
        {
            // bloco de construção de objetos
            base._configuration = configuration;

            // abre a conexão com o banco de dados
            AbrirConexao();
        }

        #endregion

        #region métodos

        public IEnumerable<TokenModel> GetAll() =>
            Conn.Query<TokenModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN");

        public IEnumerable<TokenModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Conn.Query<TokenModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public TokenModel GetById(int id) =>
            Conn.Query<TokenModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN WHERE ID = { id }", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)Conn.Query<TokenModel>($"SELECT ID TB_MAYDAY_LOGIN { where }").FirstOrDefault().Id;

        #endregion

        #region destrutores

        /// <summary>
        /// destrutor da classe TokenQuery
        /// </summary>
        ~TokenQuery() 
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}
