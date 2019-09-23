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
    public class TiposobjetosbasicasController : Controller
    {
        private readonly Bdadmincontext _context;

        public TiposobjetosbasicasController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Tiposobjetosbasicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiposobjetosbasica.ToListAsync());
        }

        // GET: Tiposobjetosbasicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposobjetosbasica = await _context.Tiposobjetosbasica
                .FirstOrDefaultAsync(m => m.IdTipoObjeto == id);
            if (tiposobjetosbasica == null)
            {
                return NotFound();
            }

            return View(tiposobjetosbasica);
        }

        // GET: Tiposobjetosbasicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiposobjetosbasicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoObjeto,NombreTipoObjeto,FechaInicial,FechaFinal,NombreTabla")] Tiposobjetosbasica tiposobjetosbasica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposobjetosbasica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposobjetosbasica);
        }

        // GET: Tiposobjetosbasicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposobjetosbasica = await _context.Tiposobjetosbasica.FindAsync(id);
            if (tiposobjetosbasica == null)
            {
                return NotFound();
            }
            return View(tiposobjetosbasica);
        }

        // POST: Tiposobjetosbasicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoObjeto,NombreTipoObjeto,FechaInicial,FechaFinal,NombreTabla")] Tiposobjetosbasica tiposobjetosbasica)
        {
            if (id != tiposobjetosbasica.IdTipoObjeto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposobjetosbasica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposobjetosbasicaExists(tiposobjetosbasica.IdTipoObjeto))
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
            return View(tiposobjetosbasica);
        }

        // GET: Tiposobjetosbasicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposobjetosbasica = await _context.Tiposobjetosbasica
                .FirstOrDefaultAsync(m => m.IdTipoObjeto == id);
            if (tiposobjetosbasica == null)
            {
                return NotFound();
            }

            return View(tiposobjetosbasica);
        }

        // POST: Tiposobjetosbasicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposobjetosbasica = await _context.Tiposobjetosbasica.FindAsync(id);
            _context.Tiposobjetosbasica.Remove(tiposobjetosbasica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposobjetosbasicaExists(int id)
        {
            return _context.Tiposobjetosbasica.Any(e => e.IdTipoObjeto == id);
        }
    }
}
