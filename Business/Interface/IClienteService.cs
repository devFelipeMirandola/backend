using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reposbackend.Domain;

namespace reposbackend.Business.Interface
{
    public interface IClienteService
    {
        Task Cadastrar(ClienteDto dto);

        Task<List<ClienteDto>> RecuperarTodos(bool somenteAtivos = true);

        Task<ClienteDto> Recuperar(int clienteId);

        Task Remover(int clienteId);

        Task Editar(ClienteDto dto);
    }
}