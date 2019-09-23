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
    public class ConfiguracioncasobasicasController : Controller
    {
        private readonly Bdadmincontext _context;

        public ConfiguracioncasobasicasController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Configuracioncasobasicas
        public async Task<IActionResult> Index()
        {
            var bdadmincontext = _context.Configuracioncasobasica.Include(c => c.IdTemporalidadNavigation);
            //return View(await _context.Configuracioncasobasica.ToListAsync());
            return View(await bdadmincontext.ToListAsync());
        }

        // GET: Configuracioncasobasicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracioncasobasica = await _context.Configuracioncasobasica
                        .Include(c => c.IdTemporalidadNavigation)
                        .FirstOrDefaultAsync(m => m.IdConfiguracionCasobasica == id);
            if (configuracioncasobasica == null)
            {
                return NotFound();
            }

            return View(configuracioncasobasica);
        }

        // GET: Configuracioncasobasicas/Create
        public IActionResult Create()
        {
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad");
            return View();
        }

        // POST: Configuracioncasobasicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracionCasobasica,FechaInicial,EtapaInicial,EtapaFinal,Descripcion,IdTemporalidad")] Configuracioncasobasica configuracioncasobasica)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(configuracioncasobasica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad");
            return View(configuracioncasobasica);
        }

        // GET: Configuracioncasobasicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracioncasobasica = await _context.Configuracioncasobasica.FindAsync(id);
            if (configuracioncasobasica == null)
            {
                return NotFound();
            }
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", configuracioncasobasica.IdTemporalidad);
          
            return View(configuracioncasobasica);
        }

        // POST: Configuracioncasobasicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfiguracionCasobasica,FechaInicial,EtapaInicial,EtapaFinal,Descripcion,IdTemporalidad")] Configuracioncasobasica configuracioncasobasica)
        {
            if (id != configuracioncasobasica.IdConfiguracionCasobasica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracioncasobasica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracioncasobasicaExists(configuracioncasobasica.IdConfiguracionCasobasica))
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
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", configuracioncasobasica.IdTemporalidad);
            return View(configuracioncasobasica);
        }

        // GET: Configuracioncasobasicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracioncasobasica = await _context.Configuracioncasobasica
                .Include(c => c.IdTemporalidadNavigation)
                .FirstOrDefaultAsync(m => m.IdConfiguracionCasobasica == id);
            if (configuracioncasobasica == null)
            {
                return NotFound();
            }

            return View(configuracioncasobasica);
        }

        // POST: Configuracioncasobasicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracioncasobasica = await _context.Configuracioncasobasica.FindAsync(id);
            _context.Configuracioncasobasica.Remove(configuracioncasobasica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracioncasobasicaExists(int id)
        {
            return _context.Configuracioncasobasica.Any(e => e.IdConfiguracionCasobasica == id);
        }
    }
}
