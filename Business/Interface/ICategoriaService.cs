using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reposbackend.Domain;

namespace reposbackend.Business.Interface
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> RecuperarTodos(bool apenasAtivos = true);
        Task<CategoriaDto> Recuperar(int categoriaId);
        Task Remover(int categoriaId);
        Task Editar(CategoriaDto dto);
        Task Adicionar(string categoria);
    }
}