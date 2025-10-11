using Microsoft.EntityFrameworkCore;
using OneManDev_PI.Models;

namespace OneManDev_PI.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Mesa)         
                .WithMany(m => m.Pedidos)    
                .HasForeignKey(p => p.MesaId); 

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Produtos);
            
        }
    }
}
