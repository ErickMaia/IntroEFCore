// See https://aka.ms/new-console-template for more information
using IntroEFCore.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("\n-- Migrações que não foram rodadas no banco de dados -- \n");

var context = new ApplicationContext(); 
var pendingMigrations = context.Database.GetPendingMigrations(); 

int contadorDeMigrations = 0; 

foreach (var migration in pendingMigrations)
{
    contadorDeMigrations++; 
    Console.WriteLine($"Migration Nº{contadorDeMigrations}: {migration}");
}

Console.WriteLine("\n-- Fim da lista de migrações que não foram rodadas no banco de dados -- \n\n");