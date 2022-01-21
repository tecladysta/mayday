using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;

namespace ArckDan.MayDay.Repositorio.Command.Acesso
{
    public class SenhaCommand : Connection, ICommand<SenhaModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe SenhaCommand
        /// </summary>
        public SenhaCommand() { }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(SenhaModel entity)
        {
            DB.Add(SenhaModel.SenhaModelFactory.ObterModel(entity.IdLogin, entity.Chave, entity.Expiracao, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(SenhaModel entity)
        {
            DB.Update(SenhaModel.SenhaModelFactory.ObterModel(entity.IdLogin, entity.Chave, entity.Expiracao, entity.Inclusao, entity.Alteracao, (int)entity.Id));
            DB.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(SenhaModel.SenhaModelFactory.ObterModel(id));
            DB.SaveChanges();
        }

        #endregion
    }
}
