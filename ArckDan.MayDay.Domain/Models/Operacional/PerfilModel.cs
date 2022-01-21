using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Domain.Models.Relacional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class PerfilModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe PerfilModel
        /// </summary>
        public PerfilModel() { }

        /// <summary>
        /// construtor da classe PerfilModel
        /// </summary>
        /// <param name="nome">nome do perfil</param>
        /// <param name="descricao">descrição do perfil</param>
        /// <param name="inclusao">data de inclusão do registro</param>
        /// <param name="alteracao">data de ateração do registro</param>
        /// <param name="id">id do registro do perfil</param>
        public PerfilModel(string nome, string descricao, DateTime inclusao, DateTime alteracao, int? id = null)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Inclusao = inclusao;
            Alteracao = alteracao;
        }

        #endregion

        #region propriedades

        [Required]
        [Column("ID", TypeName ="int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; private set; } = null!;

        [Required]
        [Column("NOME", TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; private set; }

        [Required]
        [Column("DESCRICAO", TypeName = "varchar")]
        [StringLength(200)]
        public string Descricao { get; private set; }

        [Required]
        [Column("DATA_INCLUSAO", TypeName = "datetime")]
        public DateTime Inclusao { get; private set; }

        [Required]
        [Column("DATA_ALTERACAO", TypeName = "datetime")]
        public DateTime Alteracao { get; private set; }

        [NotMapped]
        public ICollection<CampoPerfilModel> Perfil { get; set; }

        [NotMapped]
        public ICollection<UsuarioModel> Usuario { get; set; }

        [NotMapped]
        public ICollection<LoginModel> Login { get; set; }

        #endregion

        #region factory

        public static class PerfilModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="nome">nome do perfil</param>
            /// <param name="descricao">descrição do perfil</param>
            /// <param name="inclusao">data de inclusão do registro</param>
            /// <param name="alteracao">data de ateração do registro</param>
            /// <param name="id">id do registro do perfil</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static PerfilModel ObterModel(string nome, string descricao, DateTime inclusao, DateTime alteracao, int? id = null)
            {
                return new PerfilModel
                {
                    Nome = nome,
                    Descricao = descricao,
                    Inclusao = inclusao,
                    Alteracao = alteracao,
                    Id = id
                };
            }

            /// <summary>
            /// obtém o model com o id do registro
            /// </summary>
            /// <param name="id">id do registro do perfil</param>
            public static PerfilModel ObterModel(int? id = null) 
            {
                return new PerfilModel
                {
                    Id = id
                };
            }
        }

        #endregion
    }
}
