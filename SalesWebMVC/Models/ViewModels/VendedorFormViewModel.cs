using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamento { get; set; }
    }
}
