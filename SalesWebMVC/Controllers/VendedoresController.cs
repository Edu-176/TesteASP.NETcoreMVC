using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWebMVC.Models;
using SalesWebMVC.Serviços;
using SalesWebMVC.Servicos;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Servicos.Exceptions;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            List<Vendedor> lst = await _servicoVendedor.FindAllAsync();
            return View(lst);
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _servicoDepartamento.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamento = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Departamento = departamentos };
                return View(viewModel);
            }
            await _servicoVendedor.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var resul = await _servicoVendedor.FindByIdAsync(id.Value);
            if(resul == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não encontrado" });
            }
            
            return View(resul);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicoVendedor.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var resul = await _servicoVendedor.FindByIdAsync(id.Value);
            if (resul == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não encontrado" });
            }

            return View(resul);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var resul = await _servicoVendedor.FindByIdAsync(id.Value);
            if (resul == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não encontrado" });
            }
            var departamentos = await _servicoDepartamento.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamento = departamentos, Vendedor = resul};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Departamento = departamentos };
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id´s não correspondem" });
            }
            try
            {
                await _servicoVendedor.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch(DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
