using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Acesso
{
    public class LoginModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe LoginModel
        /// </summary>
        public LoginModel() { }

        /// <summary>
        /// construtor da classe LoginModel
        /// </summary>
        /// <param name="userId">user id do login</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro</param>
        public LoginModel(string userId, DateTime inclusao, DateTime alteracao, int? id = null)
        {
            UserId = userId;
            Inclusao = inclusao;
            Alteracao = alteracao;
            Id = id;
        }

        #endregion

        #region propriedades

        [Required]
        [Column("ID", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; private set; } = null!;

        [Required]
        [Column("USER_ID", TypeName = "char")]
        [StringLength(10)]
        public string UserId { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Required]
        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime Alteracao { get; private set; }

        public ICollection<SenhaModel> Senha { get; set; }

        #endregion

        #region factory

        public static class LoginModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="userId">user id do login</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static LoginModel ObterModel(string userId, DateTime inclusao, DateTime alteracao, int? id = null)
                => new LoginModel
                {
                    UserId = userId,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };

            /// <summary>
            /// obtém o model com o id do registro
            /// </summary>
            /// <param name="id">id do registro</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static LoginModel ObterModel(int? id = null)
                => new LoginModel
                {
                    Id = id
                };
        }

        #endregion
    }
}
