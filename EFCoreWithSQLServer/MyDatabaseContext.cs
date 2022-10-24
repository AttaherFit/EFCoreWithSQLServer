using EFCoreWithSQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWithSQLServer
{
    public class MyDatabaseContext : DbContext
    {
        //DbSet<T> properties map to tables in the databases

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                    "Initial Catalog=Northwind;" +
                    "Integrated Security=true;" +
                    "MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .Property(category => category.CategoryName)
                        .IsRequired() // NOT NULL
                        .HasMaxLength(15);
        }
    }
}
