using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JALLPITASBAdmin.Data;
using JALLPITASBAdmin.Models;

namespace JALLPITASBAdmin.Controllers
{
    public class CarpetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarpetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carpetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carpeta.ToListAsync());
        }

        // GET: Carpetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carpeta = await _context.Carpeta
                .FirstOrDefaultAsync(m => m.CarpetaId == id);
            if (carpeta == null)
            {
                return NotFound();
            }

            return View(carpeta);
        }

        // GET: Carpetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carpetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarpetaId,IDCarpeta,AgrupacionSocial,Cuerpos,Fojas,Poligono,FechaRegistro,Observaciones")] Carpeta carpeta)
        {
            if (ModelState.IsValid)
            {
                carpeta.FechaRegistro = DateTime.Now;
                _context.Add(carpeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carpeta);
        }

        // GET: Carpetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carpeta = await _context.Carpeta.FindAsync(id);
            if (carpeta == null)
            {
                return NotFound();
            }
            return View(carpeta);
        }

        // POST: Carpetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarpetaId,IDCarpeta,AgrupacionSocial,Cuerpos,Fojas,Poligono,FechaRegistro,Observaciones")] Carpeta carpeta)
        {
            if (id != carpeta.CarpetaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carpeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarpetaExists(carpeta.CarpetaId))
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
            return View(carpeta);
        }

        // GET: Carpetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carpeta = await _context.Carpeta
                .FirstOrDefaultAsync(m => m.CarpetaId == id);
            if (carpeta == null)
            {
                return NotFound();
            }

            return View(carpeta);
        }

        // POST: Carpetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carpeta = await _context.Carpeta.FindAsync(id);
            _context.Carpeta.Remove(carpeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarpetaExists(int id)
        {
            return _context.Carpeta.Any(e => e.CarpetaId == id);
        }
    }
}
