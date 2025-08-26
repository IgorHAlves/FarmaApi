using FarmaApi2.Entity;
using Microsoft.EntityFrameworkCore;

namespace FarmaApi2.Data.DBContext
{
    public partial class Context : DbContext
    {
        public DbSet<Client> Clients;
        public DbSet<Product> Products;
        public DbSet<Sale> Sales;

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Client>()
                .HasKey(client => client.Id);

            modelBuilder.Entity<Sale>()
                .HasKey(sale => sale.Id);

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Client)
                .WithMany()
                .HasForeignKey(sale => sale.Client.Id);

            OnModelCreationgPartial(modelBuilder);
        }
        partial void OnModelCreationgPartial(ModelBuilder modelBuilder);
    }
}
