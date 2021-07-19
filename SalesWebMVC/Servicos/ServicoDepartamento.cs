using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Servicos
{
    public class ServicoDepartamento
    {
        private readonly SalesWebMVCContext _context;

        public ServicoDepartamento(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
    }
}
