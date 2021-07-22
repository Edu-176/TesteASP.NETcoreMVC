using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Servicos
{
    public class ServicoDepartamento
    {
        private readonly SalesWebMVCContext _context;

        public ServicoDepartamento(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
