using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransporteParticular.Models;

namespace TransporteParticular.Controllers
{
    public class ClienteTablesController : Controller
    {
        private readonly MyDbContext _context;

        public ClienteTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ClienteTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteTable.ToListAsync());
        }

        // GET: ClienteTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTable = await _context.ClienteTable
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clienteTable == null)
            {
                return NotFound();
            }

            return View(clienteTable);
        }

        // GET: ClienteTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,NomeCliente,DataNascimento,Sexo,Cpf,NumeroCelular,Email,Senha,DataCadastro,TipoDeficiencia")] ClienteTable clienteTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteTable);
        }

        // GET: ClienteTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTable = await _context.ClienteTable.FindAsync(id);
            if (clienteTable == null)
            {
                return NotFound();
            }
            return View(clienteTable);
        }

        // POST: ClienteTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,NomeCliente,DataNascimento,Sexo,Cpf,NumeroCelular,Email,Senha,DataCadastro,TipoDeficiencia")] ClienteTable clienteTable)
        {
            if (id != clienteTable.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteTableExists(clienteTable.IdCliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clienteTable);
        }

        // GET: ClienteTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTable = await _context.ClienteTable
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clienteTable == null)
            {
                return NotFound();
            }

            return View(clienteTable);
        }

        // POST: ClienteTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteTable = await _context.ClienteTable.FindAsync(id);
            _context.ClienteTable.Remove(clienteTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteTableExists(int id)
        {
            return _context.ClienteTable.Any(e => e.IdCliente == id);
        }
    }
}
