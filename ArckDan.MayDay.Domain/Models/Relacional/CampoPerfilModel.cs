using ArckDan.MayDay.Domain.Models.Operacional;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArckDan.MayDay.Domain.Models.Relacional
{
    public class CampoPerfilModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe CampoPerfilModel
        /// </summary>
        public CampoPerfilModel() 
        {
            // bloco de construção de objetos
            Campo = new List<CampoModel>();
            Perfil = new List<PerfilModel>();
        }

        /// <summary>
        /// construtor da classe CampoPerfilModel
        /// </summary>
        /// <param name="idPerfil">Id do perfil de usuário</param>
        /// <param name="idCampo">Id do campo da api</param>
        /// <param name="id">Id do registro de relação entre perfil e campo</param>
        public CampoPerfilModel(int idPerfil, int idCampo, int? id = null)
        {
            // bloco de construção de objetos
            Campo = new List<CampoModel>();
            Perfil = new List<PerfilModel>();

            // preenche os dados das propriedades
            IdPerfil = idPerfil;
            IdCampo = idCampo;
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
        [JsonIgnore]
        [Column("ID_CAMPO", TypeName = "int")]
        public int IdCampo { get; private set; }

        [Required]
        [JsonIgnore]
        [Column("ID_PERFIL", TypeName = "int")]
        public int IdPerfil { get; private set; }

        [NotMapped]
        public ICollection<CampoModel> Campo { get; set; }

        [NotMapped]
        public ICollection<PerfilModel> Perfil { get; set; }

        #endregion

        #region factory

        public static class CampoPerfilModelFactory
        {
            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="idPerfil">Id do perfil de usuário</param>
            /// <param name="idCampo">Id do campo da api</param>
            /// <param name="id">Id do registro de relação entre perfil e campo</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static CampoPerfilModel ObterModel(int idPerfil, int idCampo, int? id = null)
            {
                return new CampoPerfilModel
                {
                    IdPerfil = idPerfil,
                    IdCampo = idCampo
                };
            }

            /// <summary>
            /// obtém o model com os dados completos
            /// </summary>
            /// <param name="id">id do registro do usuario</param>
            /// <returns>retorna a model com os dados completos</returns>
            public static CampoPerfilModel ObterModel(int? id = null)
            {
                return new CampoPerfilModel
                {
                    Id = id
                };
            }
        }

        #endregion
    }
}
