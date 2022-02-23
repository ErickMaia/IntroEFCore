using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroEFCore.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens"); 
            builder.HasKey(p => p.Id); 
            builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired(); 
            builder.Property(p => p.Desconto).IsRequired(); 
            builder.Property(p => p.Valor).IsRequired(); 
        }
    }
}