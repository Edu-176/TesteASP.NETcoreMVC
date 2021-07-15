using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMVC.Models.Departamento> Departamento { get; set; }
        public DbSet<SalesWebMVC.Models.Venda> Venda { get; set; }
        public DbSet<SalesWebMVC.Models.Vendedor> Vendedor { get; set; }

    }
}
