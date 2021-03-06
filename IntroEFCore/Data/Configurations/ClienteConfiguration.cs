using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroEFCore.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(p => p.Id); 
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)") .IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("CHAR(11)"); 
            builder.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired(); 
            builder.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired(); 
            builder.Property(p => p.Email).HasMaxLength(60).IsRequired(false); 

            builder.HasIndex(p => p.Telefone).HasDatabaseName("idx_cliente_telefone"); 
        }
    }
}