using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;
using reposbackend.Domain;

namespace reposbackend.Model
{
    [Table(nameof(Entrega))]
    public class Entrega
    {
        [Key]
        public int Id { get; set; }
        
        public string Endereco { get; set; }
        
        public string Anotacoes { get; set; }

        public DateTime DataAgendada { get; set; }

        public StatusEntregaEnum StatusId { get; set; }

        [ForeignKey(nameof(Venda))]
        public int VendaId { get; set; }

        public virtual Venda Venda { get; set; }
    }
}