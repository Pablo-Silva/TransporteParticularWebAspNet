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
    public class CartoesTablesController : Controller
    {
        private readonly MyDbContext _context;

        public CartoesTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CartoesTables
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.CartoesTable.Include(c => c.IdClienteNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: CartoesTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartoesTable = await _context.CartoesTable
                .Include(c => c.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCartoes == id);
            if (cartoesTable == null)
            {
                return NotFound();
            }

            return View(cartoesTable);
        }

        // GET: CartoesTables/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf");
            return View();
        }

        // POST: CartoesTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCartoes,IdCliente,TipoCartao,BandeiraCartao,NumeroCartao")] CartoesTable cartoesTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartoesTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf", cartoesTable.IdCliente);
            return View(cartoesTable);
        }

        // GET: CartoesTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartoesTable = await _context.CartoesTable.FindAsync(id);
            if (cartoesTable == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf", cartoesTable.IdCliente);
            return View(cartoesTable);
        }

        // POST: CartoesTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCartoes,IdCliente,TipoCartao,BandeiraCartao,NumeroCartao")] CartoesTable cartoesTable)
        {
            if (id != cartoesTable.IdCartoes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartoesTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartoesTableExists(cartoesTable.IdCartoes))
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
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "Cpf", cartoesTable.IdCliente);
            return View(cartoesTable);
        }

        // GET: CartoesTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartoesTable = await _context.CartoesTable
                .Include(c => c.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCartoes == id);
            if (cartoesTable == null)
            {
                return NotFound();
            }

            return View(cartoesTable);
        }

        // POST: CartoesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartoesTable = await _context.CartoesTable.FindAsync(id);
            _context.CartoesTable.Remove(cartoesTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartoesTableExists(int id)
        {
            return _context.CartoesTable.Any(e => e.IdCartoes == id);
        }
    }
}
