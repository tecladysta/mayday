using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Context;
using ArckDan.MayDay.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace ArckDan.MayDay.Repositorio.Command.Operacional
{
    public class UsuarioCommand : ICommand<UsuarioModel>
    {
        #region construtores

        /// <summary>
        /// costrutor da classe UsuarioCommand
        /// </summary>
        public UsuarioCommand(IConfiguration configuration)
        {
            // bloco de construção de objetos
            DB = new MayDayContext();
        }

        #endregion

        #region métodos

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade usuário</param>
        public void Post(UsuarioModel entity)
        {
            DB.Add(UsuarioModel.UsuarioModelFactory.ObterModel(entity.IdPerfil, entity.Nome, entity.Ativo, entity.CPF, entity.Nascimento, entity.Inclusao, entity.Alteracao));
            DB.SaveChanges();
        }

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade usuário</param>
        public void Put(UsuarioModel entity)
        {
            DB.Update(UsuarioModel.UsuarioModelFactory.ObterModel(entity.IdPerfil, entity.Nome, entity.Ativo, entity.CPF, entity.Nascimento, entity.Inclusao, entity.Alteracao, (int)entity.Id));
            DB.SaveChanges();
        }

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
        {
            DB.Remove(UsuarioModel.UsuarioModelFactory.ObterModel(id));
            DB.SaveChanges();
        }

        #endregion

        #region propriedades

        private MayDayContext DB { get; }

        #endregion
    }
}