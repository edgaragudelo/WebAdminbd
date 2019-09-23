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
    public class UnidadesbasicasController : Controller
    {
        private readonly Bdadmincontext _context;

        public UnidadesbasicasController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Unidadesbasicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidadesbasica.ToListAsync());
        }

        // GET: Unidadesbasicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesbasica = await _context.Unidadesbasica
                .FirstOrDefaultAsync(m => m.IdUnidad == id);
            if (unidadesbasica == null)
            {
                return NotFound();
            }

            return View(unidadesbasica);
        }

        // GET: Unidadesbasicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidadesbasicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUnidad,NombreUnidad")] Unidadesbasica unidadesbasica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadesbasica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadesbasica);
        }

        // GET: Unidadesbasicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesbasica = await _context.Unidadesbasica.FindAsync(id);
            if (unidadesbasica == null)
            {
                return NotFound();
            }
            return View(unidadesbasica);
        }

        // POST: Unidadesbasicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUnidad,NombreUnidad")] Unidadesbasica unidadesbasica)
        {
            if (id != unidadesbasica.IdUnidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadesbasica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesbasicaExists(unidadesbasica.IdUnidad))
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
            return View(unidadesbasica);
        }

        // GET: Unidadesbasicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesbasica = await _context.Unidadesbasica
                .FirstOrDefaultAsync(m => m.IdUnidad == id);
            if (unidadesbasica == null)
            {
                return NotFound();
            }

            return View(unidadesbasica);
        }

        // POST: Unidadesbasicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadesbasica = await _context.Unidadesbasica.FindAsync(id);
            _context.Unidadesbasica.Remove(unidadesbasica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesbasicaExists(int id)
        {
            return _context.Unidadesbasica.Any(e => e.IdUnidad == id);
        }
    }
}
