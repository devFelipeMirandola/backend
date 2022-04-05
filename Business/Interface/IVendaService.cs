using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reposbackend.Domain;

namespace reposbackend.Business.Interface
{
    public interface IVendaService
    {
        Task Gerar(NovaVendaDto dto);
    }
}