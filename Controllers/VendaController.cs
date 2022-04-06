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
    public class VendaController : BaseController
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService _vendaService)
        {
            this._vendaService = _vendaService ?? throw new ArgumentNullException(nameof(_vendaService));
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> GerarVenda(NovaVendaDto dto){
            try{
                await _vendaService.Gerar(dto);
                return Sucesso(mensagem: "Venda gerada com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }
    }
}