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
    public class RegistroVisitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroVisitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroVisitas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroVisita.Include(r => r.Departamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroVisitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVisita = await _context.RegistroVisita
                .Include(r => r.Departamento)
                .FirstOrDefaultAsync(m => m.RegistroVisitaId == id);
            if (registroVisita == null)
            {
                return NotFound();
            }

            return View(registroVisita);
        }

        // GET: RegistroVisitas/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: RegistroVisitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroVisitaId,Nombre,Ci,Celular,TipoPersona,DepartamentoId,NombreProceso,Observacion,FechaVisita")] RegistroVisita registroVisita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroVisita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", registroVisita.DepartamentoId);
            return View(registroVisita);
        }

        // GET: RegistroVisitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVisita = await _context.RegistroVisita.FindAsync(id);
            if (registroVisita == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", registroVisita.DepartamentoId);
            return View(registroVisita);
        }

        // POST: RegistroVisitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistroVisitaId,Nombre,Ci,Celular,TipoPersona,DepartamentoId,NombreProceso,Observacion,FechaVisita")] RegistroVisita registroVisita)
        {
            if (id != registroVisita.RegistroVisitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroVisita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroVisitaExists(registroVisita.RegistroVisitaId))
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
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", registroVisita.DepartamentoId);
            return View(registroVisita);
        }

        // GET: RegistroVisitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVisita = await _context.RegistroVisita
                .Include(r => r.Departamento)
                .FirstOrDefaultAsync(m => m.RegistroVisitaId == id);
            if (registroVisita == null)
            {
                return NotFound();
            }

            return View(registroVisita);
        }

        // POST: RegistroVisitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroVisita = await _context.RegistroVisita.FindAsync(id);
            _context.RegistroVisita.Remove(registroVisita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroVisitaExists(int id)
        {
            return _context.RegistroVisita.Any(e => e.RegistroVisitaId == id);
        }
    }
}
