using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Acesso
{
    public class LoginQuery : Connection, IQuery<LoginModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe LoginQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>

        public LoginQuery(IConfiguration configuration)
        {
            // bloco de construção de objetos
            _configuration = configuration;

            // abre a conexão com o banco de dados
            AbrirConexao();
        }

        #endregion

        #region métodos

        public IEnumerable<LoginModel> GetAll() =>
            Conn.Query<LoginModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN");

        public IEnumerable<LoginModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Conn.Query<LoginModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public LoginModel GetById(int id) =>
            Conn.Query<LoginModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN WHERE ID = { id }", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)Conn.Query<LoginModel>($"SELECT ID TB_MAYDAY_LOGIN { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe LoginQuery
        /// </summary>
        ~LoginQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}