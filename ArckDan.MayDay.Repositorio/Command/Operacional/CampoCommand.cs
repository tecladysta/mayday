using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class CampoCommand : Connection, ICommand<CampoModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe CampoCommand
        /// </summary>
        public CampoCommand() { }

        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(CampoModel.CampoModelFactory.ObterModel(id));
            DB.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(CampoModel entity)
        {
            DB.Add(CampoModel.CampoModelFactory.ObterModel(entity.Nome, entity.NomeTecnico, entity.Descricao, entity.Tipo, entity.Tamanho, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(CampoModel entity)
        {
            DB.Update(CampoModel.CampoModelFactory.ObterModel(entity.Nome, entity.NomeTecnico, entity.Descricao, entity.Tipo, entity.Tamanho, entity.Inclusao, entity.Alteracao, (int)entity.Id));
            DB.SaveChanges();
        }

        #endregion
    }
}
