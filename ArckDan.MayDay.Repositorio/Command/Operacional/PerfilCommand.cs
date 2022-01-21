using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Context;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class PerfilCommand : Connection, ICommand<PerfilModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe PerfilCommand
        /// </summary>
        public PerfilCommand() { }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(PerfilModel entity)
        {
            DB.Add(PerfilModel.PerfilModelFactory.ObterModel(entity.Nome, entity.Descricao, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(PerfilModel entity)
        {
            DB.Update(PerfilModel.PerfilModelFactory.ObterModel(entity.Nome, entity.Descricao, entity.Inclusao, entity.Alteracao, (int)entity.Id));
            DB.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(PerfilModel.PerfilModelFactory.ObterModel(id));
            DB.SaveChanges();
        }


        #endregion
    }
}
