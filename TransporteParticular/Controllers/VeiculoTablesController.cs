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
    public class VeiculoTablesController : Controller
    {
        private readonly MyDbContext _context;

        public VeiculoTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: VeiculoTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.VeiculoTable.ToListAsync());
        }

        // GET: VeiculoTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculoTable = await _context.VeiculoTable
                .FirstOrDefaultAsync(m => m.IdVeiculo == id);
            if (veiculoTable == null)
            {
                return NotFound();
            }

            return View(veiculoTable);
        }

        // GET: VeiculoTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VeiculoTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVeiculo,ModeloVeiculo,MarcaVeiculo,DataFabricacao")] VeiculoTable veiculoTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculoTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculoTable);
        }

        // GET: VeiculoTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculoTable = await _context.VeiculoTable.FindAsync(id);
            if (veiculoTable == null)
            {
                return NotFound();
            }
            return View(veiculoTable);
        }

        // POST: VeiculoTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVeiculo,ModeloVeiculo,MarcaVeiculo,DataFabricacao")] VeiculoTable veiculoTable)
        {
            if (id != veiculoTable.IdVeiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculoTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoTableExists(veiculoTable.IdVeiculo))
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
            return View(veiculoTable);
        }

        // GET: VeiculoTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculoTable = await _context.VeiculoTable
                .FirstOrDefaultAsync(m => m.IdVeiculo == id);
            if (veiculoTable == null)
            {
                return NotFound();
            }

            return View(veiculoTable);
        }

        // POST: VeiculoTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculoTable = await _context.VeiculoTable.FindAsync(id);
            _context.VeiculoTable.Remove(veiculoTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoTableExists(int id)
        {
            return _context.VeiculoTable.Any(e => e.IdVeiculo == id);
        }
    }
}
