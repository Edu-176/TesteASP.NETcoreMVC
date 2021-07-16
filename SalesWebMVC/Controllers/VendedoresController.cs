using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWebMVC.Models;
using SalesWebMVC.Serviços;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor Servico;

        public VendedoresController(ServicoVendedor servico)
        {
            Servico = servico;
        }

        public IActionResult Index()
        {
            List<Vendedor> lst = Servico.FindAll();
            return View(lst);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor obj)
        {
            Servico.Insert(obj);
            return RedirectToAction("Index");
        }
    }
}
