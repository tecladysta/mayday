using ArckDan.MayDay.Domain.Models.Relacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models;
using ArckDan.MayDay.WebApi.Models.Relacional;
using ArckDan.MayDay.WebApi.Models.Sistema;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Operacional
{
    public class CampoPerfilController : ControllerBase
    {
        #region atributos

        readonly IQuery<CampoPerfilModel> Query;
        readonly ICommandHandler<CampoPerfilModel> Command;
        readonly IMapper Mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CampoPerfilController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public CampoPerfilController(IQuery<CampoPerfilModel> query, ICommandHandler<CampoPerfilModel> command, IMapper mapper)
        {
            // bloco de construção de objetos
            Query = query;
            Command = command;
            Mapper = mapper;
        }

        #endregion

        #region métodos

        [Route("Post")]
        [HttpPost]
        public MensagemViewModel Post([FromBody] CampoPerfilViewModel campoPerfil)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de campos e perfis
                Command.Post(Mapper.Map<CampoPerfilModel>(campoPerfil));
                return new MensagemViewModel(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new MensagemViewModel(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemViewModel(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("Put")]
        [HttpPut]
        public MensagemViewModel Put([FromBody] CampoPerfilViewModel campoPerfil)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de campos e perfis
                Command.Put(Mapper.Map<CampoPerfilModel>(campoPerfil));
                return new MensagemViewModel(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new MensagemViewModel(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemViewModel(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public MensagemViewModel Delete(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de campos e perfis
                Command.Delete(Id);
                return new MensagemViewModel(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new MensagemViewModel(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemViewModel(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public ResultadoViewModel<CampoPerfilViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de campos e perfis
                var lista = new ResultadoViewModel<CampoPerfilViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Listagem = Mapper.Map<IEnumerable<CampoPerfilViewModel>>(Query.GetAll()),
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ResultadoViewModel<CampoPerfilViewModel>(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ResultadoViewModel<CampoPerfilViewModel>(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("GetById/{Id}")]
        [HttpGet]
        public ResultadoViewModel<CampoPerfilViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de campos e perfis
                var registro = new ResultadoViewModel<CampoPerfilViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = Mapper.Map<CampoPerfilViewModel>(Query.GetById(Id)),
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ResultadoViewModel<CampoPerfilViewModel>(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ResultadoViewModel<CampoPerfilViewModel>(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}