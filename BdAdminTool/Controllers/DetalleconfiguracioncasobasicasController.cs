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
    public class DetalleconfiguracioncasobasicasController : Controller
    {
        private readonly Bdadmincontext _context;

        public DetalleconfiguracioncasobasicasController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Detalleconfiguracioncasobasicas
        public async Task<IActionResult> Index(int? id, DateTime fechaInicial, int etapaIni, int etapaFin)
        {
            ViewData["FechaInicial"] = fechaInicial;
            ViewData["EtapaIni"] = etapaIni;
            ViewData["EtapaFin"] = etapaFin;

            var bdadmincontext = _context.Detalleconfiguracioncasobasica.Include(d => d.IdConfiguracionCasobasicaNavigation).Include(d => d.IdTemporalidadNavigation).Include(d => d.IdTipoObjetoNavigation).Include(d => d.IdTipoVariableNavigation).Include(d => d.IdVariableNavigation).Include(d => d.IdobjetoNavigation);
            return View(await bdadmincontext.ToListAsync());
        }

        // GET: Detalleconfiguracioncasobasicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleconfiguracioncasobasica = await _context.Detalleconfiguracioncasobasica
                .Include(d => d.IdConfiguracionCasobasicaNavigation)
                .Include(d => d.IdTemporalidadNavigation)
                .Include(d => d.IdTipoObjetoNavigation)
                .Include(d => d.IdTipoVariableNavigation)
                .Include(d => d.IdVariableNavigation)
                .Include(d => d.IdobjetoNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalleconfiguracioncaso == id);
            if (detalleconfiguracioncasobasica == null)
            {
                return NotFound();
            }

            return View(detalleconfiguracioncasobasica);
        }

        // GET: Detalleconfiguracioncasobasicas/Details/5
        public async Task<IActionResult> DetalleCaso(int? id, DateTime fechaInicial, int etapaIni, int etapaFin)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["FechaInicial"] = fechaInicial;
            ViewData["EtapaIni"] = etapaIni;
            ViewData["EtapaFin"] = etapaFin;


            var detalleconfiguracioncasobasica = await _context.Detalleconfiguracioncasobasica
                .Include(d => d.IdConfiguracionCasobasicaNavigation)
                .Include(d => d.IdTemporalidadNavigation)
                .Include(d => d.IdTipoObjetoNavigation)
                .Include(d => d.IdTipoVariableNavigation)
                .Include(d => d.IdVariableNavigation)
                .Include(d => d.IdobjetoNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalleconfiguracioncaso == id);
            if (detalleconfiguracioncasobasica == null)
            {
                return NotFound();
            }

            return View(detalleconfiguracioncasobasica);
        }

        // GET: Detalleconfiguracioncasobasicas/Create
        public IActionResult Create()
        {
            ViewData["IdConfiguracionCasobasica"] = new SelectList(_context.Configuracioncasobasica, "IdConfiguracionCasobasica", "Descripcion");
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad");
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto");
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable");
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable");
            ViewData["Idobjeto"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto");
            return View();
        }

        // POST: Detalleconfiguracioncasobasicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddetalleconfiguracioncaso,IdConfiguracionCasobasica,IdTipoVariable,IdVariable,IdTemporalidad,Idobjeto,IdTipoObjeto,TipoDia")] Detalleconfiguracioncasobasica detalleconfiguracioncasobasica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleconfiguracioncasobasica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConfiguracionCasobasica"] = new SelectList(_context.Configuracioncasobasica, "IdConfiguracionCasobasica", "Descripcion", detalleconfiguracioncasobasica.IdConfiguracionCasobasica);
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", detalleconfiguracioncasobasica.IdTemporalidad);
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto", detalleconfiguracioncasobasica.IdTipoObjeto);
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable", detalleconfiguracioncasobasica.IdTipoVariable);
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", detalleconfiguracioncasobasica.IdVariable);
            ViewData["Idobjeto"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto", detalleconfiguracioncasobasica.Idobjeto);
            return View(detalleconfiguracioncasobasica);
        }

        // GET: Detalleconfiguracioncasobasicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleconfiguracioncasobasica = await _context.Detalleconfiguracioncasobasica.FindAsync(id);
            if (detalleconfiguracioncasobasica == null)
            {
                return NotFound();
            }
            ViewData["IdConfiguracionCasobasica"] = new SelectList(_context.Configuracioncasobasica, "IdConfiguracionCasobasica", "Descripcion", detalleconfiguracioncasobasica.IdConfiguracionCasobasica);
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", detalleconfiguracioncasobasica.IdTemporalidad);
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto", detalleconfiguracioncasobasica.IdTipoObjeto);
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable", detalleconfiguracioncasobasica.IdTipoVariable);
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", detalleconfiguracioncasobasica.IdVariable);
            ViewData["Idobjeto"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto", detalleconfiguracioncasobasica.Idobjeto);
            return View(detalleconfiguracioncasobasica);
        }

        // POST: Detalleconfiguracioncasobasicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddetalleconfiguracioncaso,IdConfiguracionCasobasica,IdTipoVariable,IdVariable,IdTemporalidad,Idobjeto,IdTipoObjeto,TipoDia")] Detalleconfiguracioncasobasica detalleconfiguracioncasobasica)
        {
            if (id != detalleconfiguracioncasobasica.Iddetalleconfiguracioncaso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleconfiguracioncasobasica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleconfiguracioncasobasicaExists(detalleconfiguracioncasobasica.Iddetalleconfiguracioncaso))
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
            ViewData["IdConfiguracionCasobasica"] = new SelectList(_context.Configuracioncasobasica, "IdConfiguracionCasobasica", "Descripcion", detalleconfiguracioncasobasica.IdConfiguracionCasobasica);
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", detalleconfiguracioncasobasica.IdTemporalidad);
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto", detalleconfiguracioncasobasica.IdTipoObjeto);
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable", detalleconfiguracioncasobasica.IdTipoVariable);
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", detalleconfiguracioncasobasica.IdVariable);
            ViewData["Idobjeto"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto", detalleconfiguracioncasobasica.Idobjeto);
            return View(detalleconfiguracioncasobasica);
        }

        // GET: Detalleconfiguracioncasobasicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleconfiguracioncasobasica = await _context.Detalleconfiguracioncasobasica
                .Include(d => d.IdConfiguracionCasobasicaNavigation)
                .Include(d => d.IdTemporalidadNavigation)
                .Include(d => d.IdTipoObjetoNavigation)
                .Include(d => d.IdTipoVariableNavigation)
                .Include(d => d.IdVariableNavigation)
                .Include(d => d.IdobjetoNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalleconfiguracioncaso == id);
            if (detalleconfiguracioncasobasica == null)
            {
                return NotFound();
            }

            return View(detalleconfiguracioncasobasica);
        }

        // POST: Detalleconfiguracioncasobasicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleconfiguracioncasobasica = await _context.Detalleconfiguracioncasobasica.FindAsync(id);
            _context.Detalleconfiguracioncasobasica.Remove(detalleconfiguracioncasobasica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleconfiguracioncasobasicaExists(int id)
        {
            return _context.Detalleconfiguracioncasobasica.Any(e => e.Iddetalleconfiguracioncaso == id);
        }
    }
}
