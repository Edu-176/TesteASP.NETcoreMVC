using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;
using SalesWebMVC.Data;

namespace SalesWebMVC.Serviços
{
    public class ServicoVendedor
    {
        private readonly SalesWebMVCContext _context;

        public ServicoVendedor(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
        }
    }
}
