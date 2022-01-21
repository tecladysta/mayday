using ArckDan.MayDay.WebApi.Enums;
using System.Collections.Generic;

namespace ArckDan.MayDay.WebApi.Models.Sistema
{
    public class MensagemViewModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe MensagemViewModel
        /// </summary>
        /// <param name="codigo">código da mensagem</param>
        /// <param name="mensagem"descrição da mensagem></param>
        public MensagemViewModel(EMensagem codigo, string mensagem = "")
        {
            // bloco de construção de objetos
            Codigo = codigo;
            Mensagem = TratarMensagem(mensagem);
        }

        #endregion

        #region métodos

        private string TratarMensagem(string method)
        { 
            switch (method)
            {
                case "Post":
                    return "Registro cadastrado com sucesso";

                case "Put":
                    return "Registro atualizado com sucesso";

                case "Delete":
                    return "Registro excluído com sucesso";

                case "GetAll":
                    return "Foram encontrados os registros abaixo";

                case "GetById":
                    return "Foi encontrado o seguinte registro";
            }
            return null;
        }

        #endregion

        #region propriedades

        public EMensagem Codigo { get; private set; }

        public string Mensagem { get; private set; }

        #endregion
    }
}
