using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Acesso
{
    public class SenhaServico : ICommandHandler<SenhaModel>
    {
        #region atributos

        private readonly ICommand<SenhaModel> Senha;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe SenhaServico
        /// </summary>
        /// <param name="senha">objeto command de senhas</param>
        public SenhaServico(ICommand<SenhaModel> senha)
        {
            // bloco de construção de objetos
            Senha = senha;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => Senha.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Senha</param>
        public void Post(SenhaModel entity)
            => Senha.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Senha</param>
        public void Put(SenhaModel entity)
            => Senha.Put(entity);

        #endregion
    }
}
