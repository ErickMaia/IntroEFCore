using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=LAPTOP-G4OVP1BV\\SQLEXPRESS;Database=IntroEFCore;User Id=admin;Password=123;"; 
            optionsBuilder.UseSqlServer(connectionString); 
        }
    }
}