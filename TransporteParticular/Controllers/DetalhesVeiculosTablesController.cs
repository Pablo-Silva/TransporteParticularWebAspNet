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
    public class DetalhesVeiculosTablesController : Controller
    {
        private readonly MyDbContext _context;

        public DetalhesVeiculosTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: DetalhesVeiculosTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetalhesVeiculosTable.ToListAsync());
        }

        // GET: DetalhesVeiculosTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalhesVeiculosTable = await _context.DetalhesVeiculosTable
                .FirstOrDefaultAsync(m => m.IdDetalhesVeiculos == id);
            if (detalhesVeiculosTable == null)
            {
                return NotFound();
            }

            return View(detalhesVeiculosTable);
        }

        // GET: DetalhesVeiculosTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalhesVeiculosTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalhesVeiculos,PlacaVeiculo,CorVeiculo,AcentosVeiculo")] DetalhesVeiculosTable detalhesVeiculosTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalhesVeiculosTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalhesVeiculosTable);
        }

        // GET: DetalhesVeiculosTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalhesVeiculosTable = await _context.DetalhesVeiculosTable.FindAsync(id);
            if (detalhesVeiculosTable == null)
            {
                return NotFound();
            }
            return View(detalhesVeiculosTable);
        }

        // POST: DetalhesVeiculosTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalhesVeiculos,PlacaVeiculo,CorVeiculo,AcentosVeiculo")] DetalhesVeiculosTable detalhesVeiculosTable)
        {
            if (id != detalhesVeiculosTable.IdDetalhesVeiculos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalhesVeiculosTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalhesVeiculosTableExists(detalhesVeiculosTable.IdDetalhesVeiculos))
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
            return View(detalhesVeiculosTable);
        }

        // GET: DetalhesVeiculosTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalhesVeiculosTable = await _context.DetalhesVeiculosTable
                .FirstOrDefaultAsync(m => m.IdDetalhesVeiculos == id);
            if (detalhesVeiculosTable == null)
            {
                return NotFound();
            }

            return View(detalhesVeiculosTable);
        }

        // POST: DetalhesVeiculosTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalhesVeiculosTable = await _context.DetalhesVeiculosTable.FindAsync(id);
            _context.DetalhesVeiculosTable.Remove(detalhesVeiculosTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalhesVeiculosTableExists(int id)
        {
            return _context.DetalhesVeiculosTable.Any(e => e.IdDetalhesVeiculos == id);
        }
    }
}
