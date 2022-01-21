using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArckDan.MayDay.Servico.Command.Relacional
{
    public class CampoPerfilServico : ICommandHandler<CampoPerfilModel>
    {
        #region atributos

        private ICommand<CampoPerfilModel> CampoPerfil;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CampoPerfilServico
        /// </summary>
        /// <param name="campoPerfil">objeto command do campoPerfil</param>
        public CampoPerfilServico(ICommand<CampoPerfilModel> campoPerfil)
        {
            // bloco de construção de objetos
            CampoPerfil = campoPerfil;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => CampoPerfil.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade campoPerfil</param>
        public void Post(CampoPerfilModel entity)
            => CampoPerfil.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade campoPerfil</param>
        public void Put(CampoPerfilModel entity)
            => CampoPerfil.Put(entity);

        #endregion
    }
}
