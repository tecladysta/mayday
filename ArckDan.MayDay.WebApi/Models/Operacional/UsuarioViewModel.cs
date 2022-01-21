using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class UsuarioViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }

        [NotMapped]
        public ICollection<UsuarioViewModel> Usuario { get; set; }

        #endregion
    }
}
