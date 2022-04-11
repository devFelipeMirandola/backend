using backend.Model;
using Microsoft.EntityFrameworkCore;
using reposbackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options) {}
        
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Entrega> Entrega { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProduto> VendaProduto { get; set; }

    }
}