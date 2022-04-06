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
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService _categoriaService)
        {
            this._categoriaService = _categoriaService ?? throw new ArgumentNullException(nameof(_categoriaService));
        }

        [HttpGet("{somenteAtivos}")]
        [ProducesDefaultResponseType(typeof(List<CategoriaDto>))]
        public async Task<IActionResult> RecuperarTodos(bool somenteAtivos){
            try{
                var valor = await _categoriaService.RecuperarTodos(somenteAtivos);
                return Sucesso(mensagem: "Categorias recuperadas com sucesso.", dados: valor);
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpGet("{categoriaId}")]
        [ProducesDefaultResponseType(typeof(CategoriaDto))]
        public async Task<IActionResult> Recuperar(int categoriaId){
            try{
                var valor = await _categoriaService.Recuperar(categoriaId);
                return Sucesso(mensagem: "Categoria recuperada com sucesso.", dados: valor);
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpGet("{categoriaId}")]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Remover(int categoriaId){
            try{
                await _categoriaService.Remover(categoriaId);
                return Sucesso(mensagem: "Categoria removida com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Editar(CategoriaDto dto){
            try{
                await _categoriaService.Editar(dto);
                return Sucesso(mensagem: "Categoria editada com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }

        [HttpGet("{descricao}")]
        [ProducesDefaultResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> Adicionar(string descricao){
            try{
                await _categoriaService.Adicionar(descricao);
                return Sucesso(mensagem: "Categoria criada com sucesso.");
            }
            catch(Exception ex)
            { return Falha(mensagem: ex.Message); }
        }
    }
}