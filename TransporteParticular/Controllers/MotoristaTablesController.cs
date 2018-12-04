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
    public class MotoristaTablesController : Controller
    {
        private readonly MyDbContext _context;

        public MotoristaTablesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: MotoristaTables
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.MotoristaTable.Include(m => m.IdDetalhesVeiculosNavigation).Include(m => m.IdVeiculoNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: MotoristaTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motoristaTable = await _context.MotoristaTable
                .Include(m => m.IdDetalhesVeiculosNavigation)
                .Include(m => m.IdVeiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdMotorista == id);
            if (motoristaTable == null)
            {
                return NotFound();
            }

            return View(motoristaTable);
        }

        // GET: MotoristaTables/Create
        public IActionResult Create()
        {
            ViewData["IdDetalhesVeiculos"] = new SelectList(_context.DetalhesVeiculosTable, "IdDetalhesVeiculos", "PlacaVeiculo");
            ViewData["IdVeiculo"] = new SelectList(_context.VeiculoTable, "IdVeiculo", "ModeloVeiculo");
            return View();
        }

        // POST: MotoristaTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMotorista,IdVeiculo,IdDetalhesVeiculos,NomeMotorista,DataNascimento,Sexo,Cpf,NumeroCelular,Email,Senha,DataCadastro,StatusMotorista,CarteiraMotorista")] MotoristaTable motoristaTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motoristaTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDetalhesVeiculos"] = new SelectList(_context.DetalhesVeiculosTable, "IdDetalhesVeiculos", "PlacaVeiculo", motoristaTable.IdDetalhesVeiculos);
            ViewData["IdVeiculo"] = new SelectList(_context.VeiculoTable, "IdVeiculo", "ModeloVeiculo", motoristaTable.IdVeiculo);
            return View(motoristaTable);
        }

        // GET: MotoristaTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motoristaTable = await _context.MotoristaTable.FindAsync(id);
            if (motoristaTable == null)
            {
                return NotFound();
            }
            ViewData["IdDetalhesVeiculos"] = new SelectList(_context.DetalhesVeiculosTable, "IdDetalhesVeiculos", "PlacaVeiculo", motoristaTable.IdDetalhesVeiculos);
            ViewData["IdVeiculo"] = new SelectList(_context.VeiculoTable, "IdVeiculo", "ModeloVeiculo", motoristaTable.IdVeiculo);
            return View(motoristaTable);
        }

        // POST: MotoristaTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMotorista,IdVeiculo,IdDetalhesVeiculos,NomeMotorista,DataNascimento,Sexo,Cpf,NumeroCelular,Email,Senha,DataCadastro,StatusMotorista,CarteiraMotorista")] MotoristaTable motoristaTable)
        {
            if (id != motoristaTable.IdMotorista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motoristaTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaTableExists(motoristaTable.IdMotorista))
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
            ViewData["IdDetalhesVeiculos"] = new SelectList(_context.DetalhesVeiculosTable, "IdDetalhesVeiculos", "PlacaVeiculo", motoristaTable.IdDetalhesVeiculos);
            ViewData["IdVeiculo"] = new SelectList(_context.VeiculoTable, "IdVeiculo", "ModeloVeiculo", motoristaTable.IdVeiculo);
            return View(motoristaTable);
        }

        // GET: MotoristaTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motoristaTable = await _context.MotoristaTable
                .Include(m => m.IdDetalhesVeiculosNavigation)
                .Include(m => m.IdVeiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdMotorista == id);
            if (motoristaTable == null)
            {
                return NotFound();
            }

            return View(motoristaTable);
        }

        // POST: MotoristaTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motoristaTable = await _context.MotoristaTable.FindAsync(id);
            _context.MotoristaTable.Remove(motoristaTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaTableExists(int id)
        {
            return _context.MotoristaTable.Any(e => e.IdMotorista == id);
        }
    }
}
