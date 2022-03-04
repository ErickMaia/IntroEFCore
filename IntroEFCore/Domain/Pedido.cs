using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEFCore.ValueObjects;

namespace IntroEFCore.Domain
{
    public class Pedido
    {
        public Pedido(int clienteId, DateTime iniciadoEm, DateTime finalizadoEm, TipoFrete tipoFrete, StatusPedido statusPedido, ICollection<PedidoItem> itens)
        {
            ClienteId = clienteId;
            IniciadoEm = iniciadoEm;
            FinalizadoEm = finalizadoEm;
            TipoFrete = tipoFrete;
            StatusPedido = statusPedido;
            Itens = itens;
        }

        public Pedido(int id, int clienteId, Cliente cliente, DateTime iniciadoEm, DateTime finalizadoEm, TipoFrete tipoFrete, StatusPedido statusPedido, string observacao, ICollection<PedidoItem> itens)
        {
            Id = id;
            ClienteId = clienteId;
            Cliente = cliente;
            IniciadoEm = iniciadoEm;
            FinalizadoEm = finalizadoEm;
            TipoFrete = tipoFrete;
            StatusPedido = statusPedido;
            Observacao = observacao;
            Itens = itens;
        }

        public Pedido(int id, int clienteId, DateTime iniciadoEm, DateTime finalizadoEm, TipoFrete tipoFrete, StatusPedido statusPedido, string observacao, ICollection<PedidoItem> itens)
        {
            Id = id;
            ClienteId = clienteId;
            IniciadoEm = iniciadoEm;
            FinalizadoEm = finalizadoEm;
            TipoFrete = tipoFrete;
            StatusPedido = statusPedido;
            Observacao = observacao;
            Itens = itens;
        }

        public Pedido(int clienteId, DateTime iniciadoEm, DateTime finalizadoEm, TipoFrete tipoFrete, StatusPedido statusPedido, string observacao, ICollection<PedidoItem> itens)
        {
            ClienteId = clienteId;
            IniciadoEm = iniciadoEm;
            FinalizadoEm = finalizadoEm;
            TipoFrete = tipoFrete;
            StatusPedido = statusPedido;
            Observacao = observacao;
            Itens = itens;
        }

        public Pedido()
        {
            
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime FinalizadoEm { get; set; }
        public TipoFrete TipoFrete { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public string Observacao { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
    }
}