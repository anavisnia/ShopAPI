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
    }
}
