using Microsoft.EntityFrameworkCore;
using ShopWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // db tables
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        public List<Shop> GetShop()
        {
            return Shops.Include(s => s.ShopOwnersShop).ThenInclude(so => so.ShopOwner).ToList();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Products)
                .WithOne(sp => sp.Shop)
                .HasForeignKey(sp => sp.ShopId);

            modelBuilder.Entity<ShopOwnerShop>()
                .HasKey(bc => new { bc.ShopId, bc.ShopOwnerId });

            modelBuilder.Entity<ShopOwnerShop>()
                .HasOne(s => s.ShopOwner)
                .WithMany(so => so.Shops)
                .HasForeignKey(s => s.ShopOwnerId);

            modelBuilder.Entity<ShopOwnerShop>()
                .HasOne(s => s.Shop)
                .WithMany(so => so.ShopOwnersShop)
                .HasForeignKey(s => s.ShopId);
        }

    }
}
