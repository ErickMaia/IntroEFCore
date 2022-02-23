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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=LAPTOP-G4OVP1BV\\SQLEXPRESS;Database=IntroEFCore;User Id=admin;Password=123;"; 
            optionsBuilder.UseSqlServer(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(
                buildAction => {
                    buildAction.ToTable("Clientes");
                    buildAction.HasKey(p => p.Id); 
                    buildAction.Property(p => p.Nome).HasColumnType("VARCHAR(80)") .IsRequired();
                    buildAction.Property(p => p.Telefone).HasColumnType("CHAR(11)"); 
                    buildAction.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired(); 
                    buildAction.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
                    buildAction.Property(p => p.Cidade).HasMaxLength(60).IsRequired(); 

                    buildAction.HasIndex(p => p.Telefone).HasDatabaseName("idx_cliente_telefone"); 

                }
            ); 

            modelBuilder.Entity<Produto>(
                buildAction => {
                    buildAction.ToTable("Produtos"); 
                    buildAction.HasKey(p => p.Id); 
                    buildAction.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                    buildAction.Property(p => p.Descricao).HasColumnType("VARCHAR(60)"); 
                    buildAction.Property(p => p.Valor).IsRequired(); 
                    buildAction.Property(p => p.TipoProduto).HasConversion<string>();  
                }
            ); 

            modelBuilder.Entity<Pedido>(
                buildAction => {
                    buildAction.ToTable("Pedidos"); 
                    buildAction.HasKey(p => p.Id); 
                    buildAction.Property(p => p.IniciadoEm).HasDefaultValue("GETDATE()").ValueGeneratedOnAdd(); 
                    buildAction.Property(p => p.StatusPedido).HasConversion<string>(); 
                    buildAction.Property(p => p.TipoFrete).HasConversion<int>(); 
                    buildAction.Property(p => p.Observacao).HasColumnType("VARCHAR(512)"); 

                    buildAction.HasMany(p => p.Itens)
                        .WithOne(p => p.Pedido)
                        .OnDelete(DeleteBehavior.Cascade); 
                }

            );

            modelBuilder.Entity<PedidoItem>(
                buildAction => {
                    buildAction.ToTable("PedidoItens"); 
                    buildAction.HasKey(p => p.Id); 
                    buildAction.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired(); 
                    buildAction.Property(p => p.Desconto).IsRequired(); 
                    buildAction.Property(p => p.Valor).IsRequired(); 
                }
            ); 
        }

    }
}