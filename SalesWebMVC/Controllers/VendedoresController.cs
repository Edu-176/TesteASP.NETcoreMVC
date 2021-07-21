using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWebMVC.Models;
using SalesWebMVC.Serviços;
using SalesWebMVC.Servicos;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Servicos.Exceptions;

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
            _servicoVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var resul = _servicoVendedor.FindById(id.Value);
            if(resul == null)
            {
                return NotFound();
            }
            
            return View(resul);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resul = _servicoVendedor.FindById(id.Value);
            if (resul == null)
            {
                return NotFound();
            }

            return View(resul);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resul = _servicoVendedor.FindById(id.Value);
            if (resul == null)
            {
                return NotFound();
            }
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new VendedorFormViewModel { Departamento = departamentos, Vendedor = resul};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return BadRequest();
            }
            try
            {
                _servicoVendedor.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch(DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
