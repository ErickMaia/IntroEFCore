using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntroEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole()); 
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=LAPTOP-G4OVP1BV\\SQLEXPRESS;Database=IntroEFCore;User Id=admin;Password=123;"; 
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString, 
                    p => p.EnableRetryOnFailure()); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly); 
            MapearPropriedadesEsquecidas(modelBuilder); 
        }

        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder){
            var entityTypes = modelBuilder.Model.GetEntityTypes(); 

            foreach (var entityType in entityTypes)
            {
                var properties = entityType.GetProperties().Where(p => p.ClrType == typeof(string)); 

                foreach (var property in properties)
                {
                    if(string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue ){
                        //property.SetMaxLength(100); 
                        property.SetColumnType("VARCHAR(100)"); 
                    }
                }
            }
        }

    }
}