using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models;
using ArckDan.MayDay.WebApi.Models.Operacional;
using ArckDan.MayDay.WebApi.Models.Sistema;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Operacional
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        #region atributos

        readonly IQuery<PerfilModel> _query;
        readonly ICommandHandler<PerfilModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe PerfilController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public PerfilController(IQuery<PerfilModel> query, ICommandHandler<PerfilModel> command, IMapper mapper) 
        {
            // bloco de construção de objetos
            _query = query;
            _command = command;
            _mapper = mapper;
        }

        #endregion

        #region métodos

        [Route("Post")]
        [HttpPost]
        public MensagemViewModel Post([FromBody] PerfilViewModel perfil)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                _command.Post(_mapper.Map<PerfilModel>(perfil));
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
        public MensagemViewModel Put([FromBody] PerfilViewModel perfil)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                _command.Put(_mapper.Map<PerfilModel>(perfil));
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
                // executa o processo de inclusão do registro de perfil
                _command.Delete(Id);
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
        public ResultadoViewModel<PerfilViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var lista = new ResultadoViewModel<PerfilViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Listagem = _mapper.Map<IEnumerable<PerfilViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ResultadoViewModel<PerfilViewModel>(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ResultadoViewModel<PerfilViewModel>(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("GetById/{Id}")]
        [HttpGet]
        public ResultadoViewModel<PerfilViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var registro = new ResultadoViewModel<PerfilViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<PerfilViewModel>(_query.GetById(Id)),
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ResultadoViewModel<PerfilViewModel>(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ResultadoViewModel<PerfilViewModel>(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}