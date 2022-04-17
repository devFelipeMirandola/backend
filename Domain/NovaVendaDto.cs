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
        public bool Entrega { get; set; }
        public EntregaDto DadosEntrega { get; set; }
        public List<ProdutoVendaDto> Produtos { get; set; }
    }

    public class ProdutoVendaDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
    }

    public class EntregaDto {
        public string Endereco { get; set; }
        public string Anotacoes { get; set; }
        public DateTime DataEntrega { get; set; }
    }

    public class RetornoEntregaDto {
        public RetornoEntregaDto()
        {
            Produtos = new List<ProdutosEntregaDto>();
        }

        public string Endereco { get; set; }
        public string Anotacoes { get; set; }
        public DateTime DataAgendada { get; set; }
        public List<ProdutosEntregaDto> Produtos { get; set; }
    }

    public class ProdutosEntregaDto {
        public string Produto { get; set; }
        public string Observacao { get; set; }
        public int Quantidade { get; set; }
    }
}