using DotNet5Sample.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNet5Sample.Core.Context
{
    public class StoreDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public StoreDbContext()
        {

        }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public StoreDbContext(DbContextOptions<StoreDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetial { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("StoreContext");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.ToTable("offer", "dbo");
                entity.Property(e => e.id)
                    .HasMaxLength(50);
                entity.Property(e => e.name).HasMaxLength(100);
                entity.Property(e => e.version).HasMaxLength(100);
                entity.Property(e => e.approve).HasMaxLength(100);
            });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Product", "dbo");
                entity.Property(e => e.Id)
                    .HasMaxLength(50);
                entity.Property(e => e.Product_Name).HasMaxLength(100);
                entity.Property(e => e.Price).HasMaxLength(100);
                entity.Property(e => e.Qnt).HasMaxLength(100);
            });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Order_Id);
                entity.ToTable("Order", "dbo");
                entity.Property(e => e.Order_Id)
                    .HasMaxLength(50);
                entity.Property(e => e.Order_NameCus).HasMaxLength(100);
                entity.Property(e => e.TotalPrice).HasMaxLength(100);
                entity.Property(e => e.Status).HasMaxLength(100);
            });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetial_Id);
                entity.ToTable("OrderDetial", "dbo");
                entity.Property(e => e.OrderDetial_Id)
                    .HasMaxLength(50);
                entity.Property(e => e.Order_Id).HasMaxLength(100);
                entity.Property(e => e.Product_Id).HasMaxLength(100);
                entity.Property(e => e.Qnt).HasMaxLength(100);
            });
        }
    }
}
