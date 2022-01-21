using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Operacional
{
    public class PerfilQuery : Connection, IQuery<PerfilModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe PerfilQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>

        public PerfilQuery(IConfiguration configuration) 
        {
            // bloco de construção de objetos
            _configuration = configuration;

            // abre a conexão com o banco de dados
            AbrirConexao();
        }

        #endregion

        #region métodos

        public IEnumerable<PerfilModel> GetAll() =>
            Conn.Query<PerfilModel>($"SELECT ID, NOME, DESCRICAO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_PERFIL");

        public IEnumerable<PerfilModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Conn.Query<PerfilModel>($"SELECT ID, NOME, DESCRICAO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_PERFIL { where } ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty )}"); 

        public PerfilModel GetById(int id) =>
            Conn.Query<PerfilModel>($"SELECT ID, NOME, DESCRICAO, INCLUSAO, ALTERACAO FROM TB_MAYDAY_PERFIL WHERE ID = @Id", new { Id = id }).FirstOrDefault();
        
        public int GetTotalCount(string where = "") =>
            (int)Conn.Query<PerfilModel>($"SELECT ID TB_MAYDAY_PERFIL { where }").FirstOrDefault().Id;

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe PerfilQuery
        /// </summary>
        ~PerfilQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}