using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Servicos.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMVC.Serviços
{
    public class ServicoVendedor
    {
        private readonly SalesWebMVCContext _context;

        public ServicoVendedor(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(elem => elem.Departamento).FirstOrDefaultAsync(elem => elem.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Vendedor não pode ser excluido quando tem vendas relacionadas à ele.");
            }
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            if(! await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Vendedor.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
