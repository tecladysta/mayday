using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class EnderecoCommand : Connection, ICommand<EnderecoModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe EnderecoCommand
        /// </summary>
        public EnderecoCommand() {  }

        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(EnderecoModel.EnderecoModelFactory.ObterModel(id));
            DB.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Post(EnderecoModel entity)
        {
            DB.Add(EnderecoModel.EnderecoModelFactory.ObterModel(entity.IdUsuario, entity.CEP, entity.Logradouro, entity.Numero, entity.Complemento, entity.Bairro, entity.Cidade, entity.UF, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade perfil</param>
        public void Put(EnderecoModel entity)
        {
            DB.Update(EnderecoModel.EnderecoModelFactory.ObterModel(entity.IdUsuario, entity.CEP, entity.Logradouro, entity.Numero, entity.Complemento, entity.Bairro, entity.Cidade, entity.UF, entity.Inclusao, entity.Alteracao, (int)entity.Id));
            DB.SaveChanges();
        }

        #endregion
    }
}
