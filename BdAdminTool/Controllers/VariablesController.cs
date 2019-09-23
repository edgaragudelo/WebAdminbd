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
    public class VariablesController : Controller
    {
        private readonly Bdadmincontext _context;

        public VariablesController(Bdadmincontext context)
        {
            _context = context;
        }

        // GET: Variables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Variables.ToListAsync());
        }

        // GET: Variables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variables = await _context.Variables
                .FirstOrDefaultAsync(m => m.IdVariable == id);
            if (variables == null)
            {
                return NotFound();
            }

            return View(variables);
        }

        // GET: Variables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Variables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVariable,NombreVariable,FechaInicial,FechaFinal")] Variables variables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(variables);
        }

        // GET: Variables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variables = await _context.Variables.FindAsync(id);
            if (variables == null)
            {
                return NotFound();
            }
            return View(variables);
        }

        // POST: Variables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVariable,NombreVariable,FechaInicial,FechaFinal")] Variables variables)
        {
            if (id != variables.IdVariable)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariablesExists(variables.IdVariable))
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
            return View(variables);
        }

        // GET: Variables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variables = await _context.Variables
                .FirstOrDefaultAsync(m => m.IdVariable == id);
            if (variables == null)
            {
                return NotFound();
            }

            return View(variables);
        }

        // POST: Variables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variables = await _context.Variables.FindAsync(id);
            _context.Variables.Remove(variables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariablesExists(int id)
        {
            return _context.Variables.Any(e => e.IdVariable == id);
        }
    }
}
