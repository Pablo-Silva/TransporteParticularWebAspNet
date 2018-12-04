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
    public class ViagemTablesController : Controller
    {
        private readonly MyDbContext _context;

        public ViagemTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ViagemTables
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ViagemTable.Include(v => v.IdClienteNavigation).Include(v => v.IdMotoristaNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ViagemTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemTable = await _context.ViagemTable
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdMotoristaNavigation)
                .FirstOrDefaultAsync(m => m.IdViagem == id);
            if (viagemTable == null)
            {
                return NotFound();
            }

            return View(viagemTable);
        }

        // GET: ViagemTables/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "NomeCliente");
            ViewData["IdMotorista"] = new SelectList(_context.MotoristaTable, "IdMotorista", "NomeMotorista");
            return View();
        }

        // POST: ViagemTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdViagem,IdMotorista,IdCliente,EnderecoSaida,EnderecoChegada,DataInicio,DataFim")] ViagemTable viagemTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagemTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "NomeCliente", viagemTable.IdCliente);
            ViewData["IdMotorista"] = new SelectList(_context.MotoristaTable, "IdMotorista", "NomeMotorista", viagemTable.IdMotorista);
            return View(viagemTable);
        }

        // GET: ViagemTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemTable = await _context.ViagemTable.FindAsync(id);
            if (viagemTable == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "NomeCliente", viagemTable.IdCliente);
            ViewData["IdMotorista"] = new SelectList(_context.MotoristaTable, "IdMotorista", "NomeMotorista", viagemTable.IdMotorista);
            return View(viagemTable);
        }

        // POST: ViagemTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdViagem,IdMotorista,IdCliente,EnderecoSaida,EnderecoChegada,DataInicio,DataFim")] ViagemTable viagemTable)
        {
            if (id != viagemTable.IdViagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagemTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemTableExists(viagemTable.IdViagem))
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
            ViewData["IdCliente"] = new SelectList(_context.ClienteTable, "IdCliente", "NomeCliente", viagemTable.IdCliente);
            ViewData["IdMotorista"] = new SelectList(_context.MotoristaTable, "IdMotorista", "NomeMotorista", viagemTable.IdMotorista);
            return View(viagemTable);
        }

        // GET: ViagemTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemTable = await _context.ViagemTable
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdMotoristaNavigation)
                .FirstOrDefaultAsync(m => m.IdViagem == id);
            if (viagemTable == null)
            {
                return NotFound();
            }

            return View(viagemTable);
        }

        // POST: ViagemTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagemTable = await _context.ViagemTable.FindAsync(id);
            _context.ViagemTable.Remove(viagemTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemTableExists(int id)
        {
            return _context.ViagemTable.Any(e => e.IdViagem == id);
        }
    }
}
