using Microsoft.EntityFrameworkCore;
using ProductsApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders {  get; set; }
        public DbSet<ProductOrderModel> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProductOrders.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrderModel>()
           .HasOne(sc => sc.Product)
           .WithMany(s => s.ProductOrders)
           .HasForeignKey(sc => sc.ProductId);

            modelBuilder.Entity<ProductOrderModel>()
                .HasOne(sc => sc.Order)
                .WithMany(c => c.ProductOrders)
                .HasForeignKey(sc => sc.OrderId);
        }
    }
}
