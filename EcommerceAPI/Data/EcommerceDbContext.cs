using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define precisão para decimal (evita o aviso/truncamento)
            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasPrecision(18, 2);

            // Opcional: limita tamanho de strings (bom para DB)
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(200);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Categoria)
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}
