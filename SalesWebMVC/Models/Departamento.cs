using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Departamento
    {
        private int _id;
        private string _name;
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Departamento()
        {
        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AdcVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio, final));
        }
    }
}
