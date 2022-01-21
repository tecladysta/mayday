using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class PerfilServico : ICommandHandler<PerfilModel>
    {
        #region atributos

        private readonly ICommand<PerfilModel> Perfil;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe PerfilServico
        /// </summary>
        /// <param name="perfil">objeto command do perfil</param>
        public PerfilServico(ICommand<PerfilModel> perfil)
        {
            // bloco de construção de objetos
            Perfil = perfil;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id) 
            => Perfil.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(PerfilModel entity)
            => Perfil.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(PerfilModel entity) 
            => Perfil.Put(entity);

        #endregion
    }
}
