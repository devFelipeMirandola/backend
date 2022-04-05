using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reposbackend.Domain
{
    public class NovaVendaDto
    {
        public NovaVendaDto()
        {
            Produtos = new List<ProdutoVendaDto>();
        }
        public int? ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public List<ProdutoVendaDto> Produtos { get; set; }
    }

    public class ProdutoVendaDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}