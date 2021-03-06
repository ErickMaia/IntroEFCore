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

// //INSERINDO REGISTROS EM MASSA

// var listAProdutos = new List<Produto>(){
//     new Produto(
//         "4923837571",
//         "Produto de teste EFCore 2", 
//         50, 
//         TipoProduto.MercadoriaParaRevenda, 
//         true), 
//     new Produto(
//         "9203848123",
//         "Produto de teste EFCore 3", 
//         46, 
//         TipoProduto.Servico, 
//         false)
// }; 

// context.Produtos.AddRange(listAProdutos); 
// context.SaveChanges(); 


// //INSERINDO REGISTROS PARA EXEMPLO DE CONSULTA
// context.Clientes.AddRange(
//     new Cliente(
//         "Erick Maia", 
//         "9999999999",
//         "88888888", 
//         "AA", 
//         "Micklândia", 
//         ""
//     ), 
//     new Cliente(
//         "Mick Areia", 
//         "8888888888", 
//         "88888888", 
//         "AA", 
//         "Micklândia", 
//         "mickareia@mickareia.com"
//     ) 
// ); 

// context.SaveChanges(); 


// //CONSULTANDO DADOS

// //var clientesComEmailConsultaPorSintaxeLinq = (from c in context.Clientes where c.Email != "" select c).ToList();
// var clientesComEmailConsultaPorMetodoLinq = context.Clientes.Where(c => c.Email != "").ToList(); 

// clientesComEmailConsultaPorMetodoLinq.ForEach(c => System.Console.WriteLine(c.ToString())); 


// //CARREGAMENTO ADIANTADO

// //cadastrando pedido com pedidoItem
// var cliente = context.Clientes.FirstOrDefault(); 
// var produto = context.Produtos.FirstOrDefault(); 


// if(cliente is not null && produto is not null){
    
//     Pedido pedido = new Pedido(cliente.Id, 
//         DateTime.Now,
//         DateTime.Now, 
//         TipoFrete.SemFrete, 
//         StatusPedido.Analise,
//         "",
//         new List<PedidoItem>(){
//             new PedidoItem(
//                 produto.Id,
//                 1,
//                 30, 
//                 3
//             )
//         }); 

//     context.Pedidos.Add(pedido); 

//     context.SaveChanges(); 

// }

// consultando o pedido gravado

// var pedidos = 
//     context.Pedidos
//         .Include(p => p.Itens)
//             .ThenInclude(i => i.Produto)
//         .Include(p => p.Cliente).ToList(); 

// System.Console.WriteLine(pedidos.Count()); 


// // ATUALIZANDO REGISTROS

// var cliente = context.Clientes.Find(3); 

// cliente.Nome = "Cliente alterado"; 

//context.Clientes.Update(cliente); 

// // O método Update acima atualiza todas as propriedades forçadamente mesmo que seu valor não tenha mudado.  
// // Para atualizar apenas as propriedades modificadas no SQL gerado pelo EF Core, 
// // basta alterar o valor da propriedade e chamar SaveChanges()

// context.SaveChanges(); 


// // exemplo de atualização de registro com cliente desconectado
// // exemplo: receber atualização de apenas dois campos desde um frontend para executar na API
// // nossa tarefa é atualizar apenas os campos informados no JSON

// var cliente = context.Clientes.Find(3); 

// if(cliente is not null){

//     var clienteDesconectado = new {
//         Nome = "Cliente atualizado desde JSON fornecido por frontend", 
//         Telefone = "7777777777"
//     }; 

//     context.Entry(cliente).CurrentValues.SetValues(clienteDesconectado); 

//     context.SaveChanges(); 
// }


// REMOVENDO REGISTROS

// é possível buscar do banco de dados como na linha seguinte
var cliente = context.Clientes.Find(3);

// ou criar uma entidade desconectada para realizar a remoção, 
// sem rodar o SELECT que o comando anterior faria para verificar se o registro existe
//var clienteDesconectado = new Cliente() {Id = 3}; 


//diferentes alterantivas de comando de remoção

//remoção com o método Remove
context.Clientes.Remove(cliente); 

//remoção alterando o status da entidade (seria a forma de remover utilizando clienteDesconectado)
//context.Entry(cliente).State = EntityState.Deleted

context.SaveChanges(); 