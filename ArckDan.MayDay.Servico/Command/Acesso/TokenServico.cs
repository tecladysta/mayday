using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Acesso
{
    public class TokenServico : ICommandHandler<TokenModel>
    {
        #region atributos

        private readonly ICommand<TokenModel> Token;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe TokenServico
        /// </summary>
        /// <param name="token">objeto command do token</param>
        public TokenServico(ICommand<TokenModel> token)
        {
            // bloco de construção de objetos
            Token = token;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => Token.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade token</param>
        public void Post(TokenModel entity)
            => Token.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade token</param>
        public void Put(TokenModel entity)
            => Token.Put(entity);

        #endregion
    }
}