using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;

namespace ArckDan.MayDay.Repositorio.Command.Acesso
{
    public class TokenCommand : Connection, ICommand<TokenModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe TokenCommand
        /// </summary>
        public TokenCommand() { }

        #endregion
        
        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade token</param>
        public void Post(TokenModel entity)
        {
            DB.Add(TokenModel.TokenModelFactory.ObterModel(entity.UserId, entity.Senha, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade token</param>
        public void Put(TokenModel entity)
        {
            DB.Update(TokenModel.TokenModelFactory.ObterModel(entity.UserId, entity.Senha, entity.Inclusao, entity.Alteracao, entity.Id));
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
