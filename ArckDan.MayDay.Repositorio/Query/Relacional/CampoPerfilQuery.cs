using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ArckDan.MayDay.Repositorio.Query.Relacional
{
    public class CampoPerfilQuery : IQuery<CampoPerfilModel>
    {
        #region atributos

        readonly IConfiguration _configuration;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CampoQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>

        public CampoPerfilQuery(IConfiguration configuration)
        {
            // bloco de construção de objetos
            _configuration = configuration;

            // abre a conexão com o banco de dados
            Connection.Open();
        }

        #endregion

        #region métodos

        public IEnumerable<CampoPerfilModel> GetAll() =>
            Connection.Query<CampoPerfilModel, CampoModel, PerfilModel, CampoPerfilModel>
                ($@"SELECT B.ID
                         , A.ID
                         , A.NOME
                         , A.NOME_TECNICO
                         , A.DESCRICAO
                         , A.TIPO
                         , A.TAMANHO
                         , A.INCLUSAO
                         , A.ALTERACAO
                         , C.ID
                         , C.NOME
                         , C.DESCRICAO
                         , C.INCLUSAO
                         , C.ALTERACAO 
                    FROM TB_MAYDAY_CAMPO A INNER JOIN TB_MAYDAY_CAMPO_PERFIL B ON A.ID = B.ID_CAMPO 
                    INNER JOIN TB_MAYDAY_PERFIL C ON B.ID_PERFIL = C.ID ",
                (a, b, c) => {
                    a.Campo.Add(b); a.Perfil.Add(c); return a;
                }, splitOn:
                (
                  @"  ID
                    , ID
                    , ID"
                )).AsQueryable();

        public IEnumerable<CampoPerfilModel> GetAll(string where = "", int? nroPagina = 0, int? regPorPagina = 20) =>
            Connection.Query<CampoPerfilModel, CampoModel, PerfilModel, CampoPerfilModel>
            ($@"SELECT B.ID
                         , A.ID
                         , A.NOME
                         , A.NOME_TECNICO
                         , A.DESCRICAO
                         , A.TIPO
                         , A.TAMANHO
                         , A.INCLUSAO
                         , A.ALTERACAO
                         , C.ID
                         , C.NOME
                         , C.DESCRICAO
                         , C.INCLUSAO
                         , C.ALTERACAO
                    FROM TB_MAYDAY_CAMPO A INNER JOIN TB_MAYDAY_CAMPO_PERFIL B ON A.ID = B.ID_CAMPO
                    INNER JOIN TB_MAYDAY_PERFIL C ON B.ID_PERFIL = C.ID  { where } 
                    ORDER BY { (nroPagina > 0 ? $"OFFSET { (nroPagina - 1) * regPorPagina } ROWSFETCH NEXT { nroPagina } ROWSONLY " : string.Empty)}",
                    (a, b, c) => {
                        a.Campo.Add(b); a.Perfil.Add(c); return a;
                    }, splitOn:
                    (
                      @"  ID
                        , ID
                        , ID"
                    )).AsQueryable();

        public CampoPerfilModel GetById(int id) =>
            Connection.Query<CampoPerfilModel, CampoModel, PerfilModel, CampoPerfilModel>(@$"SELECT B.ID
                         , A.ID
                         , A.NOME
                         , A.NOME_TECNICO
                         , A.DESCRICAO
                         , A.TIPO
                         , A.TAMANHO
                         , A.INCLUSAO
                         , A.ALTERACAO
                         , C.ID
                         , C.NOME
                         , C.DESCRICAO
                         , C.INCLUSAO
                         , C.ALTERACAO
                    FROM TB_MAYDAY_CAMPO A INNER JOIN TB_MAYDAY_CAMPO_PERFIL B ON A.ID = B.ID_CAMPO
                    INNER JOIN TB_MAYDAY_PERFIL C ON B.ID_PERFIL = C.ID WHERE B.ID = { id }",
                    (a, b, c) => {
                        a.Campo.Add(b); a.Perfil.Add(c); return a;
                    }, splitOn:
                    (
                      @"  ID
                        , ID
                        , ID"
                    )).FirstOrDefault();

        public int GetTotalCount(string where = "") =>
            (int)Connection.Query<CampoPerfilModel>($"SELECT ID TB_MAYDAY_CAMPO_PERFIL { where }").FirstOrDefault().Id;

        #endregion

        #region propriedades

        private IDbConnection Connection =>
            new SqlConnection(_configuration.GetConnectionString("MayDayDev"));

        #endregion
    }
}