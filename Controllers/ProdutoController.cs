using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Business.Interface;
using backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;
        
        public ProdutoController(IProdutoService _produtoService){
            this._produtoService = _produtoService ?? throw new ArgumentNullException(nameof(_produtoService));
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Cadastrar(ProdutoDto produtoDto){
            try{
                await _produtoService.Cadastrar(produtoDto);
                return Sucesso(mensagem: "Produto cadastrado com sucesso.");
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }

        [HttpGet("{produtoId}")]
        [ProducesDefaultResponseType(typeof(ProdutoDto))]
        public async Task<IActionResult> Recuperar(int produtoId){
            try{
                var dados = await _produtoService.Recuperar(produtoId);
                return Sucesso(dados: dados, mensagem: "Produto recuperado com sucesso.");
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }
        
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<ProdutoDto>))]
        public async Task<IActionResult> RecuperarTodos(){
            try{
                var dados = await _produtoService.RecuperarTodos();
                return Sucesso(dados: dados, mensagem: "Produtos recuperados com sucesso.");
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }

        [HttpGet("{produtoId}")]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Remover(int produtoId){
            try{
                await _produtoService.Remover(produtoId);
                return Sucesso(mensagem: "Produto removido com sucesso.");
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }
        
        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Editar(ProdutoDto dto){
            try{
                await _produtoService.Editar(dto);
                return Sucesso(mensagem: "Produto editado com sucesso");
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }
    }
}