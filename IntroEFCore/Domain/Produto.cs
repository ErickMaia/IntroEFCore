using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEFCore.ValueObjects;

namespace IntroEFCore.Domain
{
    public class Produto
    {
        public Produto()
        {
            
        }
        public Produto(string codigoBarras, string descricao, decimal valor, TipoProduto tipoProduto, bool ativo)
        {
            CodigoBarras = codigoBarras;
            Descricao = descricao;
            Valor = valor;
            TipoProduto = tipoProduto;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}