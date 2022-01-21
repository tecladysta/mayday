using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models;
using ArckDan.MayDay.WebApi.Models.Acesso;
using ArckDan.MayDay.WebApi.Models.Sistema;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Acesso
{
    [ApiController]
    [EnableCors("mayday-api-policy")]
    [Authorize("MayDayApi")]
    [ApiExplorerSettings(GroupName = "MayDayApi")]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        #region atributos

        readonly IQuery<LoginModel> _query;
        readonly ICommandHandler<LoginModel> command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe LoginController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public LoginController(IQuery<LoginModel> query, ICommandHandler<LoginModel> command, IMapper mapper)
        {
            // bloco de construção de objetos
            _query = query;
            this.command = command;
            _mapper = mapper;
        }

        #endregion

        #region métodos

        [Route("Post")]
        [HttpPost]
        public MensagemViewModel Post([FromBody] LoginViewModel login)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de login
                command.Post(_mapper.Map<LoginModel>(login));
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
        public MensagemViewModel Put([FromBody] LoginViewModel login)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de alteração do registro de login
                command.Put(_mapper.Map<LoginModel>(login));
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
                // executa o processo de exclusão do registro de login
                command.Delete(Id);
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
                // executa a consulta dos registros de login
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
                // executa a consulta do registro de login por id
                var registro = new ResultadoViewModel<LoginViewModel>(Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<LoginViewModel>(_query.GetById(Id))
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