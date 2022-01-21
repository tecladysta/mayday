using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models;
using ArckDan.MayDay.WebApi.Models.Acesso;
using ArckDan.MayDay.WebApi.Models.Sistema;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Acesso
{
    [ApiController]
    [Route("[controller]")]
    public class SenhaController : ControllerBase
    {
        #region atributos

        readonly IQuery<SenhaModel> _query;
        readonly ICommandHandler<SenhaModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe LoginController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public SenhaController(IQuery<SenhaModel> query, ICommandHandler<SenhaModel> command, IMapper mapper)
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
        public MensagemViewModel Post([FromBody] SenhaViewModel senha)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                _command.Post(_mapper.Map<SenhaModel>(senha));
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
        public MensagemViewModel Put([FromBody] SenhaViewModel senha)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                _command.Put(_mapper.Map<SenhaModel>(senha));
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
                // executa o processo de inclusão do registro de usuário
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
        public ResultadoViewModel<LoginViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                var lista = new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Listagem = _mapper.Map<IEnumerable<LoginViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("GetById/{Id}")]
        [HttpGet]
        public ResultadoViewModel<LoginViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                var registro = new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<LoginViewModel>(_query.GetById(Id)),
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}