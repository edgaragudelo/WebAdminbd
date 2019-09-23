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
    public class TemporalidadesbasicasController : Controller
    {
        private readonly Bdadmincontext _context;

        public TemporalidadesbasicasController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Temporalidadesbasicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temporalidadesbasica.ToListAsync());
        }

        // GET: Temporalidadesbasicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporalidadesbasica = await _context.Temporalidadesbasica
                .FirstOrDefaultAsync(m => m.Idtemporalidad == id);
            if (temporalidadesbasica == null)
            {
                return NotFound();
            }

            return View(temporalidadesbasica);
        }

        // GET: Temporalidadesbasicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temporalidadesbasicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtemporalidad,NombreTemporalidad")] Temporalidadesbasica temporalidadesbasica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temporalidadesbasica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temporalidadesbasica);
        }

        // GET: Temporalidadesbasicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporalidadesbasica = await _context.Temporalidadesbasica.FindAsync(id);
            if (temporalidadesbasica == null)
            {
                return NotFound();
            }
            return View(temporalidadesbasica);
        }

        // POST: Temporalidadesbasicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtemporalidad,NombreTemporalidad")] Temporalidadesbasica temporalidadesbasica)
        {
            if (id != temporalidadesbasica.Idtemporalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temporalidadesbasica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemporalidadesbasicaExists(temporalidadesbasica.Idtemporalidad))
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
            return View(temporalidadesbasica);
        }

        // GET: Temporalidadesbasicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporalidadesbasica = await _context.Temporalidadesbasica
                .FirstOrDefaultAsync(m => m.Idtemporalidad == id);
            if (temporalidadesbasica == null)
            {
                return NotFound();
            }

            return View(temporalidadesbasica);
        }

        // POST: Temporalidadesbasicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temporalidadesbasica = await _context.Temporalidadesbasica.FindAsync(id);
            _context.Temporalidadesbasica.Remove(temporalidadesbasica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemporalidadesbasicaExists(int id)
        {
            return _context.Temporalidadesbasica.Any(e => e.Idtemporalidad == id);
        }
    }
}
