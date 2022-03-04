using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroEFCore.Domain
{
    public class PedidoItem
    {
        public PedidoItem(int produtoId, int quantidade, decimal valor, decimal desconto)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Valor = valor;
            Desconto = desconto;
        }

        public PedidoItem(int id, int pedidoId, Pedido pedido, int produtoId, Produto produto, int quantidade, decimal valor, decimal desconto)
        {
            Id = id;
            PedidoId = pedidoId;
            Pedido = pedido;
            ProdutoId = produtoId;
            Produto = produto;
            Quantidade = quantidade;
            Valor = valor;
            Desconto = desconto;
        }

        public PedidoItem()
        {
            
        }

        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
    }
}