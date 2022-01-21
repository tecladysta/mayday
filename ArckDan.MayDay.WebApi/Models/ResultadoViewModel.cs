using ArckDan.MayDay.WebApi.Models.Sistema;
using System.Collections.Generic;

namespace ArckDan.MayDay.WebApi.Models
{
    public class ResultadoViewModel<TEntity> where TEntity : class
    {
        #region construtores

        /// <summary>
        /// construtora da classe ResultadoViewModel
        /// </summary>
        /// <param name="codigo">código da mensagem de retorno</param>
        /// <param name="mensagem">mensagem de retorno</param>
        public ResultadoViewModel(Enums.EMensagem codigo, string mensagem = "")
        {
            Mensagem = new MensagemViewModel(codigo, mensagem);
            Listagem = new List<TEntity>();
        }

        #endregion

        #region propriedades

        public MensagemViewModel Mensagem { get; set; }

        public IEnumerable<TEntity> Listagem { get; set; }

        public TEntity Registro { get; set; }

        #endregion
    }
}
