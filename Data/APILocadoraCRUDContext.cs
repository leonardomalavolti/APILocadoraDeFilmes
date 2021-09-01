using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APILocadoraCRUD.Models;

namespace APILocadoraCRUD.Data
{
    public class APILocadoraCRUDContext : DbContext
    {
        public APILocadoraCRUDContext (DbContextOptions<APILocadoraCRUDContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Locacao>()
                .HasKey(e => new { e.IdCliente, e.IdFilme });

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacaos { get; set; }
    }
}
