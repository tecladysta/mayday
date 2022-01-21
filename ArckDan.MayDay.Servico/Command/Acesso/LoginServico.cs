using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Acesso
{
    public class LoginServico : ICommandHandler<LoginModel>
    {
        #region atributos

        private readonly ICommand<LoginModel> Login;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe LoginServico
        /// </summary>
        /// <param name="login">objeto command do Login</param>
        public LoginServico(ICommand<LoginModel> login)
        {
            // bloco de construção de objetos
            Login = login;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => Login.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Login</param>
        public void Post(LoginModel entity)
            => Login.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Login</param>
        public void Put(LoginModel entity)
            => Login.Put(entity);

        #endregion
    }
}
