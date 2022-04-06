using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using reposbackend.Business.Interface;
using reposbackend.Domain;

namespace reposbackend.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService _clienteService)
        {
            this._clienteService = _clienteService ?? throw new ArgumentNullException(nameof(_clienteService));
        }

        [HttpGet("{clienteId}")]
        [ProducesDefaultResponseType(typeof(ClienteDto))]
        public async Task<IActionResult> Recuperar(int clienteId){
            try {
                var dados = await _clienteService.Recuperar(clienteId);
                return Sucesso(dados: dados, mensagem: "Cliente recuperado com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpGet("{somenteAtivos}")]
        [ProducesDefaultResponseType(typeof(List<ClienteDto>))]
        public async Task<IActionResult> RecuperarTodos(bool somenteAtivos){
            try {
                var dados = await _clienteService.RecuperarTodos(somenteAtivos);
                return Sucesso(dados: dados, mensagem: "Clientes recuperados com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Cadastrar(ClienteDto dto){
            try {
                await _clienteService.Cadastrar(dto);
                return Sucesso(mensagem: "Cliente cadastrado com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Editar(ClienteDto dto){
            try {
                await _clienteService.Editar(dto);
                return Sucesso(mensagem: "Cliente editado com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpGet("{clienteId}")]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Remover(int clienteId){
            try {
                await _clienteService.Remover(clienteId);
                return Sucesso(mensagem: "Cliente removido com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }
    }
}