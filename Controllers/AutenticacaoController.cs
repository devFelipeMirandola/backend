using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using reposbackend.Business.Interface;

namespace reposbackend.Controllers
{
    public class AutenticacaoController : BaseController
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService _autenticacaoService)
        {
            this._autenticacaoService = _autenticacaoService ?? throw new ArgumentNullException(nameof(_autenticacaoService));
        }

        [HttpGet("{login}/{senha}")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Logar(string login, string senha){
            try{
                var dados = await _autenticacaoService.RecuperarToken(login, senha);
                return Sucesso(dados: dados, mensagem: "Logado com sucesso.");
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }
    }
}