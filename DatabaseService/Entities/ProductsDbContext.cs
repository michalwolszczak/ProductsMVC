using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Entities
{
    public class ProductsDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=ProductsDb;Trusted_Connection=True;Encrypt=False";

        public DbSet<Product> Products { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
