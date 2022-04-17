using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reposbackend.Domain;
using reposbackend.Model;

namespace reposbackend.Business.Interface
{
    public interface IEntregaService
    {
        Entrega AgendarEntrega(EntregaDto entrega);
    }
}