using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using reposbackend.Model;

namespace backend.Model
{
    public class Venda
    {
        public Venda()
        {
            Produtos = new HashSet<VendaProduto>();
        }
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(Cliente))]
        public int? ClienteId { get; set; }

        public string NomeCliente { get; set; }

        public DateTime DataCriacao { get; set; }

        public virtual ICollection<VendaProduto> Produtos { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Entrega Entrega { get; set; }
    }
}