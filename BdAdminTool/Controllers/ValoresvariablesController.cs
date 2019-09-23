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
    public class ValoresvariablesController : Controller
    {
        private readonly Bdadmincontext _context;

        public ValoresvariablesController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Valoresvariables
        public async Task<IActionResult> Index()
        {
            var bdadmincontext = _context.Valoresvariables.Include(v => v.IdObjetoSistemaNavigation).Include(v => v.IdTemporalidadNavigation).Include(v => v.IdTipoObjetoNavigation).Include(v => v.IdTipoVariableNavigation).Include(v => v.IdVariableNavigation).Include(v => v.IdunidadNavigation);
            return View(await bdadmincontext.ToListAsync());
        }

        // GET: Valoresvariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoresvariables = await _context.Valoresvariables
                .Include(v => v.IdObjetoSistemaNavigation)
                .Include(v => v.IdTemporalidadNavigation)
                .Include(v => v.IdTipoObjetoNavigation)
                .Include(v => v.IdTipoVariableNavigation)
                .Include(v => v.IdVariableNavigation)
                .Include(v => v.IdunidadNavigation)
                .FirstOrDefaultAsync(m => m.IdValorVariable == id);
            if (valoresvariables == null)
            {
                return NotFound();
            }

            return View(valoresvariables);
        }

        // GET: Valoresvariables/Create
        public IActionResult Create()
        {
            ViewData["IdObjetoSistema"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto");
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad");
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto");
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable");
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable");
            ViewData["Idunidad"] = new SelectList(_context.Unidadesbasica, "IdUnidad", "NombreUnidad");
            return View();
        }

        // POST: Valoresvariables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdValorVariable,IdTipoVariable,IdVariable,Valor,Fecha,Periodo,IdTemporalidad,Idunidad,IdObjetoSistema,IdTipoObjeto,Fuente,TipoDia")] Valoresvariables valoresvariables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valoresvariables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdObjetoSistema"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto", valoresvariables.IdObjetoSistema);
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", valoresvariables.IdTemporalidad);
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto", valoresvariables.IdTipoObjeto);
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable", valoresvariables.IdTipoVariable);
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", valoresvariables.IdVariable);
            ViewData["Idunidad"] = new SelectList(_context.Unidadesbasica, "IdUnidad", "NombreUnidad", valoresvariables.Idunidad);
            return View(valoresvariables);
        }

        // GET: Valoresvariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoresvariables = await _context.Valoresvariables.FindAsync(id);
            if (valoresvariables == null)
            {
                return NotFound();
            }
            ViewData["IdObjetoSistema"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto", valoresvariables.IdObjetoSistema);
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", valoresvariables.IdTemporalidad);
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto", valoresvariables.IdTipoObjeto);
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable", valoresvariables.IdTipoVariable);
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", valoresvariables.IdVariable);
            ViewData["Idunidad"] = new SelectList(_context.Unidadesbasica, "IdUnidad", "NombreUnidad", valoresvariables.Idunidad);
            return View(valoresvariables);
        }

        // POST: Valoresvariables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdValorVariable,IdTipoVariable,IdVariable,Valor,Fecha,Periodo,IdTemporalidad,Idunidad,IdObjetoSistema,IdTipoObjeto,Fuente,TipoDia")] Valoresvariables valoresvariables)
        {
            if (id != valoresvariables.IdValorVariable)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valoresvariables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValoresvariablesExists(valoresvariables.IdValorVariable))
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
            ViewData["IdObjetoSistema"] = new SelectList(_context.Objetossistemabasica, "IdobjetoSistema", "NombreObjeto", valoresvariables.IdObjetoSistema);
            ViewData["IdTemporalidad"] = new SelectList(_context.Temporalidadesbasica, "Idtemporalidad", "NombreTemporalidad", valoresvariables.IdTemporalidad);
            ViewData["IdTipoObjeto"] = new SelectList(_context.Tiposobjetosbasica, "IdTipoObjeto", "NombreTipoObjeto", valoresvariables.IdTipoObjeto);
            ViewData["IdTipoVariable"] = new SelectList(_context.Tipovariables, "IdTipoVariable", "NombreTipoVariable", valoresvariables.IdTipoVariable);
            ViewData["IdVariable"] = new SelectList(_context.Variables, "IdVariable", "NombreVariable", valoresvariables.IdVariable);
            ViewData["Idunidad"] = new SelectList(_context.Unidadesbasica, "IdUnidad", "NombreUnidad", valoresvariables.Idunidad);
            return View(valoresvariables);
        }

        // GET: Valoresvariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoresvariables = await _context.Valoresvariables
                .Include(v => v.IdObjetoSistemaNavigation)
                .Include(v => v.IdTemporalidadNavigation)
                .Include(v => v.IdTipoObjetoNavigation)
                .Include(v => v.IdTipoVariableNavigation)
                .Include(v => v.IdVariableNavigation)
                .Include(v => v.IdunidadNavigation)
                .FirstOrDefaultAsync(m => m.IdValorVariable == id);
            if (valoresvariables == null)
            {
                return NotFound();
            }

            return View(valoresvariables);
        }

        // POST: Valoresvariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valoresvariables = await _context.Valoresvariables.FindAsync(id);
            _context.Valoresvariables.Remove(valoresvariables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValoresvariablesExists(int id)
        {
            return _context.Valoresvariables.Any(e => e.IdValorVariable == id);
        }
    }
}
