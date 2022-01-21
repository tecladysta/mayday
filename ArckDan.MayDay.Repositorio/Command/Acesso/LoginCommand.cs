using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;

namespace ArckDan.MayDay.Repositorio.Command.Acesso
{
    public class LoginCommand : Connection, ICommand<LoginModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe LoginCommand
        /// </summary>
        public LoginCommand() { }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade login</param>
        public void Post(LoginModel entity)
        {
            DB.Add(LoginModel.LoginModelFactory.ObterModel(entity.UserId, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade login</param>
        public void Put(LoginModel entity)
        {
            DB.Update(LoginModel.LoginModelFactory.ObterModel(entity.UserId, entity.Inclusao, entity.Alteracao, (int)entity.Id));
            DB.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(LoginModel.LoginModelFactory.ObterModel(id));
            DB.SaveChanges();
        }

        #endregion
    }
}
