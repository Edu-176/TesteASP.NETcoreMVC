using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() || _context.Venda.Any() || _context.Vendedor.Any())
            {
                return;
            }

            Departamento d1 = new Departamento(1, "Eletronicos");
            Departamento d2 = new Departamento(2, "Comida");
            Departamento d3 = new Departamento(3, "Limpeza");
            Departamento d4 = new Departamento(4, "Roupas");

            Vendedor s1 = new Vendedor(1, "Fernando", "fernandin@gmail.com", new DateTime(1996, 07, 15), 1.500, d1);
            Vendedor s2 = new Vendedor(2, "Bruno", "brunon@gmail.com", new DateTime(1990, 02, 01), 1.800, d2);
            Vendedor s3 = new Vendedor(3, "Alexandre", "lelexandre@gmail.com", new DateTime(2001, 02, 15), 1.900, d1);
            Vendedor s4 = new Vendedor(4, "Eduardo", "edu_a@gmail.com", new DateTime(1999, 06, 10), 1.400, d3);
            Vendedor s5 = new Vendedor(5, "Larissa", "lara1@gmail.com", new DateTime(1994, 06, 11), 1.100, d4);

            Venda r1 = new Venda(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Pendente, s1);
            Venda r2 = new Venda(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Faturado, s5);
            Venda r3 = new Venda(3, new DateTime(2018, 09, 13), 4000.0, SaleStatus.Cancelado, s4);
            Venda r4 = new Venda(4, new DateTime(2018, 09, 1), 8000.0, SaleStatus.Pendente, s1);
            Venda r5 = new Venda(5, new DateTime(2018, 09, 21), 3000.0, SaleStatus.Pendente, s3);
            Venda r6 = new Venda(6, new DateTime(2018, 09, 15), 2000.0, SaleStatus.Faturado, s1);
            Venda r7 = new Venda(7, new DateTime(2018, 09, 28), 13000.0, SaleStatus.Pendente, s2);
            Venda r8 = new Venda(8, new DateTime(2018, 09, 11), 4000.0, SaleStatus.Faturado, s4);
            Venda r9 = new Venda(9, new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pendente, s4);
            Venda r10 = new Venda(10, new DateTime(2018, 09, 7), 9000.0, SaleStatus.Cancelado, s5);

            _context.Departamento.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(s1, s2, s3, s4, s5);

            _context.Venda.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();
        }           
    }
}
