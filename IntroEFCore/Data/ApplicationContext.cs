using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=LAPTOP-G4OVP1BV\\SQLEXPRESS;Database=IntroEFCore;User Id=admin;Password=123;"; 
            optionsBuilder.UseSqlServer(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly); 
        }

    }
}