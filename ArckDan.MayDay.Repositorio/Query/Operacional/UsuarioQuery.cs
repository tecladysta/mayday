using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Cadastro
{
    public class UsuarioQuery : Connection, IQuery<UsuarioModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe UsuarioQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>

        public UsuarioQuery()
        {
            // abre a conexão com o banco de dados
            AbrirConexao();
        }

        #endregion

        #region métodos

        public IEnumerable<UsuarioModel> GetAll() =>
            Conn.Query<UsuarioModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN");

        public IEnumerable<UsuarioModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Conn.Query<UsuarioModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}");

        public UsuarioModel GetById(int id) =>
            Conn.Query<UsuarioModel>($"SELECT ID, ID_PERFIL, USER_ID, INCLUSAO, ALTERACAO FROM TB_MAYDAY_LOGIN WHERE ID = @Id", new { Id = id }).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)Conn.Query<UsuarioModel>($"SELECT ID TB_MAYDAY_LOGIN { where }").FirstOrDefault().Id;

        #endregion

        #region destrutores

        /// <summary>
        /// destrutor da classe UsuarioQuery
        /// </summary>
        ~UsuarioQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}