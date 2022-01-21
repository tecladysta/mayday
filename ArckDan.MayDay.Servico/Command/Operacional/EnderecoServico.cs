using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArckDan.MayDay.Servico.Command.Operacional
{
    public class EnderecoServico : ICommandHandler<EnderecoModel>
    {
        #region atributos

        private readonly ICommand<EnderecoModel> Endereco;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe EnderecoServico
        /// </summary>
        /// <param name="endereco">objeto command do endereço do usuário</param>
        public EnderecoServico(ICommand<EnderecoModel> endereco)
        {
            // bloco de construção de objetos
            Endereco = endereco;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int id)
            => Endereco.Delete(id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Endereco</param>
        public void Post(EnderecoModel entity)
            => Endereco.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Endereco</param>
        public void Put(EnderecoModel entity)
            => Endereco.Put(entity);

        #endregion
    }
}
