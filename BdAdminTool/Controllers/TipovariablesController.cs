using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminbdTool.Models;

namespace WebAdminbdTool.Controllers
{
    public class TipovariablesController : Controller
    {
        private readonly Bdadmincontext _context;

        public TipovariablesController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Tipovariables
        public async Task<IActionResult> Index()
        {
            var bdadmincontext = _context.Tipovariables.Include(t => t.IdVariableNavigation);
            return View(await bdadmincontext.ToListAsync());
        }

        // GET: Tipovariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipovariables = await _context.Tipovariables
                .Include(t => t.IdVariableNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoVariable == id);
            if (tipovariables == null)
            {
                return NotFound();
            }

            return View(tipovariables);
        }

        // GET: Tipovariables/Create
        public IActionResult Create()
        {
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable");
            return View();
        }

        // POST: Tipovariables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoVariable,IdVariable,NombreTipoVariable,FechaInicial,FechaFinal")] Tipovariables tipovariables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipovariables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", tipovariables.IdVariable);
            return View(tipovariables);
        }

        // GET: Tipovariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipovariables = await _context.Tipovariables.FindAsync(id);
            if (tipovariables == null)
            {
                return NotFound();
            }
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", tipovariables.IdVariable);
            return View(tipovariables);
        }

        // POST: Tipovariables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoVariable,IdVariable,NombreTipoVariable,FechaInicial,FechaFinal")] Tipovariables tipovariables)
        {
            if (id != tipovariables.IdTipoVariable)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipovariables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipovariablesExists(tipovariables.IdTipoVariable))
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
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", tipovariables.IdVariable);
            return View(tipovariables);
        }

        // GET: Tipovariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipovariables = await _context.Tipovariables
                .Include(t => t.IdVariableNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoVariable == id);
            if (tipovariables == null)
            {
                return NotFound();
            }

            return View(tipovariables);
        }

        // POST: Tipovariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipovariables = await _context.Tipovariables.FindAsync(id);
            _context.Tipovariables.Remove(tipovariables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipovariablesExists(int id)
        {
            return _context.Tipovariables.Any(e => e.IdTipoVariable == id);
        }
    }
}
