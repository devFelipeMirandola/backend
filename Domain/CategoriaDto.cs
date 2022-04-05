using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reposbackend.Domain
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}