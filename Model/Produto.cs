using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    [Table(nameof(Produto))]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Imagem { get; set; }

        public int Estoque { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
        
        public virtual Categoria Categoria { get; set; }
    }
}