using FarmaApi2.Entity;
using Microsoft.EntityFrameworkCore;

namespace FarmaApi2.Data.DBContext
{
    public partial class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Client>()
                .HasKey(client => client.Id);

            modelBuilder.Entity<Sale>()
                .HasKey(sale => sale.Id);


            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Client)
                .WithMany(client => client.Sales)
                .HasForeignKey(sale => sale.ClientId);


            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Client)
                .WithMany(client => client.Sales)
                .HasForeignKey(sale => sale.ClientId);
            
            OnModelCreationgPartial(modelBuilder);
        }
        partial void OnModelCreationgPartial(ModelBuilder modelBuilder);
    }
}
