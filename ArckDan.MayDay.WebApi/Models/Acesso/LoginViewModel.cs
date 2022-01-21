using System;

namespace ArckDan.MayDay.WebApi.Models.Acesso
{
    public class LoginViewModel
    {
        #region propriedades

        public int? Id { get; set; }

        public int IdPerfil { get; set; }

        public string UserId { get; set; }

        public DateTime Inclusao { get; set; }

        public DateTime Alteracao { get; set; }

        #endregion
    }
}
