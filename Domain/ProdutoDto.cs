using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain
{
    public class ProdutoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Imagem { get; set; }

        public int Estoque { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        public int CategoriaId { get; set; }
    }
}