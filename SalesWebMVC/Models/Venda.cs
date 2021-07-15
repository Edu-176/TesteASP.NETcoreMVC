using System;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double ValorVenda { get; set; }
        public SaleStatus Status { get; set; }

        public Vendedor Vendedor { get; set; }

        public Venda()
        {
        }

        public Venda(int id, DateTime data, double valorVenda, SaleStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            ValorVenda = valorVenda;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
