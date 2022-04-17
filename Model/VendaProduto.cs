using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    [Table(nameof(VendaProduto))]
    public class VendaProduto
    {
        [Key]
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }

        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}