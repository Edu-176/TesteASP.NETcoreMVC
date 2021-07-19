using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWebMVC.Models;
using SalesWebMVC.Serviços;
using SalesWebMVC.Servicos;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }

        public IActionResult Index()
        {
            List<Vendedor> lst = _servicoVendedor.FindAll();
            return View(lst);
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new VendedorFormViewModel { Departamento = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            
            //Console.WriteLine(obj);
            _servicoVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
