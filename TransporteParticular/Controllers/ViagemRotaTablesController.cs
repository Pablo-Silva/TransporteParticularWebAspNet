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
    public class ViagemRotaTablesController : Controller
    {
        private readonly MyDbContext _context;

        public ViagemRotaTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ViagemRotaTables
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ViagemRotaTable.Include(v => v.IdViagemNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ViagemRotaTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemRotaTable = await _context.ViagemRotaTable
                .Include(v => v.IdViagemNavigation)
                .FirstOrDefaultAsync(m => m.IdViagemRota == id);
            if (viagemRotaTable == null)
            {
                return NotFound();
            }

            return View(viagemRotaTable);
        }

        // GET: ViagemRotaTables/Create
        public IActionResult Create()
        {
            ViewData["IdViagem"] = new SelectList(_context.ViagemTable, "IdViagem", "EnderecoChegada");
            return View();
        }

        // POST: ViagemRotaTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdViagemRota,IdViagem,Latidute,Longitude")] ViagemRotaTable viagemRotaTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagemRotaTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdViagem"] = new SelectList(_context.ViagemTable, "IdViagem", "EnderecoChegada", viagemRotaTable.IdViagem);
            return View(viagemRotaTable);
        }

        // GET: ViagemRotaTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemRotaTable = await _context.ViagemRotaTable.FindAsync(id);
            if (viagemRotaTable == null)
            {
                return NotFound();
            }
            ViewData["IdViagem"] = new SelectList(_context.ViagemTable, "IdViagem", "EnderecoChegada", viagemRotaTable.IdViagem);
            return View(viagemRotaTable);
        }

        // POST: ViagemRotaTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdViagemRota,IdViagem,Latidute,Longitude")] ViagemRotaTable viagemRotaTable)
        {
            if (id != viagemRotaTable.IdViagemRota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagemRotaTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemRotaTableExists(viagemRotaTable.IdViagemRota))
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
            ViewData["IdViagem"] = new SelectList(_context.ViagemTable, "IdViagem", "EnderecoChegada", viagemRotaTable.IdViagem);
            return View(viagemRotaTable);
        }

        // GET: ViagemRotaTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagemRotaTable = await _context.ViagemRotaTable
                .Include(v => v.IdViagemNavigation)
                .FirstOrDefaultAsync(m => m.IdViagemRota == id);
            if (viagemRotaTable == null)
            {
                return NotFound();
            }

            return View(viagemRotaTable);
        }

        // POST: ViagemRotaTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagemRotaTable = await _context.ViagemRotaTable.FindAsync(id);
            _context.ViagemRotaTable.Remove(viagemRotaTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemRotaTableExists(int id)
        {
            return _context.ViagemRotaTable.Any(e => e.IdViagemRota == id);
        }
    }
}
