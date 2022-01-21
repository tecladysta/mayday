using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Context;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArckDan.MayDay.Repositorio.Command.Relacional
{
    public class CampoPerfilCommand : ICommand<CampoPerfilModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe CampoPerfilCommand
        /// </summary>
        public CampoPerfilCommand(IConfiguration configuration)
        {
            // bloco de construção de objetos
            DB = new MayDayContext();
        }

        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(CampoPerfilModel.CampoPerfilModelFactory.ObterModel(id));
            DB.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(CampoPerfilModel entity)
        {
            DB.Add(CampoPerfilModel.CampoPerfilModelFactory.ObterModel(entity.IdPerfil, entity.IdCampo));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(CampoPerfilModel entity)
        {
            DB.Update(CampoPerfilModel.CampoPerfilModelFactory.ObterModel(entity.IdPerfil, entity.IdCampo, (int)entity.Id));
            DB.SaveChanges();
        }

        #endregion

        #region propriedades

        private MayDayContext DB { get; }

        #endregion
    }
}
