using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> lst = new List<Departamento>();
            lst.Add(new Departamento { Id = 1, Name = "Eletronicos" });
            lst.Add(new Departamento { Id = 2, Name = "Roupas" });

            return View(lst);
        }
    }
}
