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
    public class DinheiroTablesController : Controller
    {
        private readonly MyDbContext _context;

        public DinheiroTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: DinheiroTables
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.DinheiroTable.Include(d => d.IdClienteNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: DinheiroTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinheiroTable = await _context.DinheiroTable
                .Include(d => d.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdDinheiro == id);
            if (dinheiroTable == null)
            {
                return NotFound();
            }

            return View(dinheiroTable);
        }

        // GET: DinheiroTables/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf");
            return View();
        }

        // POST: DinheiroTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDinheiro,IdCliente,TipoDinheiro")] DinheiroTable dinheiroTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dinheiroTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf", dinheiroTable.IdCliente);
            return View(dinheiroTable);
        }

        // GET: DinheiroTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinheiroTable = await _context.DinheiroTable.FindAsync(id);
            if (dinheiroTable == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf", dinheiroTable.IdCliente);
            return View(dinheiroTable);
        }

        // POST: DinheiroTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDinheiro,IdCliente,TipoDinheiro")] DinheiroTable dinheiroTable)
        {
            if (id != dinheiroTable.IdDinheiro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dinheiroTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DinheiroTableExists(dinheiroTable.IdDinheiro))
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
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf", dinheiroTable.IdCliente);
            return View(dinheiroTable);
        }

        // GET: DinheiroTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinheiroTable = await _context.DinheiroTable
                .Include(d => d.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdDinheiro == id);
            if (dinheiroTable == null)
            {
                return NotFound();
            }

            return View(dinheiroTable);
        }

        // POST: DinheiroTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dinheiroTable = await _context.DinheiroTable.FindAsync(id);
            _context.DinheiroTable.Remove(dinheiroTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DinheiroTableExists(int id)
        {
            return _context.DinheiroTable.Any(e => e.IdDinheiro == id);
        }
    }
}
