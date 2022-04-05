using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain;

namespace backend.Business.Interface
{
    public interface IProdutoService
    {
        Task Cadastrar(ProdutoDto dto);
        Task Editar(ProdutoDto dto);
        Task Remover(int produtoId);
        Task<ProdutoDto> Recuperar(int produtoId);
        Task<List<ProdutoDto>> RecuperarTodos(bool somenteAtivos = true);
    }
}