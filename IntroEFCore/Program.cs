// See https://aka.ms/new-console-template for more information
using IntroEFCore.Data;
using IntroEFCore.Domain;
using IntroEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

var context = new ApplicationContext(); 

// //MIGRAÇÕES

// Console.WriteLine("\n-- Migrações que não foram rodadas no banco de dados -- \n");

// var pendingMigrations = context.Database.GetPendingMigrations(); 

// int contadorDeMigrations = 0; 

// foreach (var migration in pendingMigrations)
// {
//     contadorDeMigrations++; 
//     Console.WriteLine($"Migration Nº{contadorDeMigrations}: {migration}");
// }

// Console.WriteLine("\n-- Fim da lista de migrações que não foram rodadas no banco de dados -- \n\n");

// //ADICIONANDO PRODUTO

// var produto = new Produto(
//     "12852934049",
//     "Produto de teste EFCore", 
//     20, 
//     TipoProduto.MercadoriaParaRevenda, 
//     true); 

// //diferentes formas de adicionar
// context.Produtos.Add(produto); 
// context.Add(produto); 
// context.Set<Produto>().Add(produto); 
// context.Entry(produto).State = EntityState.Added; //não depende de DbSet

// //salva 1 registro apenas apesar dos 4 comandos acima, pois o rastreamento é feito por instância
// int registrosAfetados = context.SaveChanges(); 

// System.Console.WriteLine($"Foram inseridos {registrosAfetados} registros. ");

//INSERINDO REGISTROS EM MASSA

var listAProdutos = new List<Produto>(){
    new Produto(
        "4923837571",
        "Produto de teste EFCore 2", 
        50, 
        TipoProduto.MercadoriaParaRevenda, 
        true), 
    new Produto(
        "9203848123",
        "Produto de teste EFCore 3", 
        46, 
        TipoProduto.Servico, 
        false)
}; 

context.Produtos.AddRange(listAProdutos); 
context.SaveChanges(); 
