using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TiendaContext:DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options):base(options)
        {
            
        }

        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
            .Property(p => p.Valor)
            .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Producto>()
             .HasOne(p => p.Tienda)
             .WithMany(t => t.Productos)
             .HasForeignKey(p => p.TiendaId)
             .IsRequired();
        }

    }
}
