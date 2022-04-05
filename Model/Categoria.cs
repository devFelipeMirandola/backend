using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    [Table(nameof(Categoria))]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}