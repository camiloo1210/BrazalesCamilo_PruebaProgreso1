using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrazalesCamilo_PruebaProgreso1.Models;

namespace BrazalesCamilo_PruebaProgreso1.Controllers
{
    public class CBrazalesController : Controller
    {
        private readonly Pruebaprogreso1 _context;

        public CBrazalesController(Pruebaprogreso1 context)
        {
            _context = context;
        }

        // GET: CBrazales
        public async Task<IActionResult> Index()
        {
            var pruebaprogreso1 = _context.CBrazales.Include(c => c.Celular);
            return View(await pruebaprogreso1.ToListAsync());
        }

        // GET: CBrazales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cBrazales = await _context.CBrazales
                .Include(c => c.Celular)
                .FirstOrDefaultAsync(m => m.Id_usuario == id);
            if (cBrazales == null)
            {
                return NotFound();
            }

            return View(cBrazales);
        }

        // GET: CBrazales/Create
        public IActionResult Create()
        {
            ViewData["Id_celular"] = new SelectList(_context.Set<Celular>(), "Id_celular", "CelularNombre");
            return View();
        }

        // POST: CBrazales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_usuario,Nombre,Tiene_trabajo,Ingreso,Salario,Id_celular")] CBrazales cBrazales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cBrazales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_celular"] = new SelectList(_context.Set<Celular>(), "Id_celular", "CelularNombre", cBrazales.Id_celular);
            return View(cBrazales);
        }

        // GET: CBrazales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cBrazales = await _context.CBrazales.FindAsync(id);
            if (cBrazales == null)
            {
                return NotFound();
            }
            ViewData["Id_celular"] = new SelectList(_context.Set<Celular>(), "Id_celular", "CelularNombre", cBrazales.Id_celular);
            return View(cBrazales);
        }

        // POST: CBrazales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_usuario,Nombre,Tiene_trabajo,Ingreso,Salario,Id_celular")] CBrazales cBrazales)
        {
            if (id != cBrazales.Id_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cBrazales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CBrazalesExists(cBrazales.Id_usuario))
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
            ViewData["Id_celular"] = new SelectList(_context.Set<Celular>(), "Id_celular", "CelularNombre", cBrazales.Id_celular);
            return View(cBrazales);
        }

        // GET: CBrazales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cBrazales = await _context.CBrazales
                .Include(c => c.Celular)
                .FirstOrDefaultAsync(m => m.Id_usuario == id);
            if (cBrazales == null)
            {
                return NotFound();
            }

            return View(cBrazales);
        }

        // POST: CBrazales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cBrazales = await _context.CBrazales.FindAsync(id);
            if (cBrazales != null)
            {
                _context.CBrazales.Remove(cBrazales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CBrazalesExists(int id)
        {
            return _context.CBrazales.Any(e => e.Id_usuario == id);
        }
    }
}
