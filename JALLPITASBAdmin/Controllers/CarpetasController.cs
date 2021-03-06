﻿using System;
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
            return View(await _context.Carpetas.Include(d => d.Departamento).Include(p => p.Provincia).Include(m => m.Municipio).ToListAsync());
        }

        // GET: Carpetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carpeta = await _context.Carpetas
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
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: Carpetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarpetaId,IDCarpeta,DepartamentoId,ProvinciaId,MunicipioId,AgrupacionSocial,Cuerpos,Fojas,Poligono,Observaciones")] Carpeta carpeta)
        {
            //var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                        
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

            var carpeta = await _context.Carpetas.FindAsync(id);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias.Where(c => c.DepartamentoId == carpeta.DepartamentoId).ToList(), "ProvinciaId", "Nombre");
            ViewData["MunicipioId"] = new SelectList(_context.Municipios.Where(c => c.ProvinciaId == carpeta.ProvinciaId).ToList(), "MunicipioId", "Nombre");
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
        public async Task<IActionResult> Edit(int id, [Bind("CarpetaId,IDCarpeta,AgrupacionSocial,Cuerpos,Fojas,Poligono,FechaRegistro,Observaciones,DepartamentoId,ProvinciaId,MunicipioId")] Carpeta carpeta)
        {
            //var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
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

            var carpeta = await _context.Carpetas
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
            var carpeta = await _context.Carpetas.FindAsync(id);
            _context.Carpetas.Remove(carpeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarpetaExists(int id)
        {
            return _context.Carpetas.Any(e => e.CarpetaId == id);
        }

        //<Script>
        //Obtener todos las provincias de un Departamento
        public JsonResult GetProvinciabyid(int id)
        {
            List<Provincia> provincias = new List<Provincia>();
            provincias = _context.Provincias.Where(De => De.Departamento.DepartamentoId == id).ToList();
            //list.Insert(0, new Provincia { ProvinciaId = 0, Nombre = "Por favor Seleccione la Provincias" });
            return Json(new SelectList(provincias, "ProvinciaId", "Nombre"));
        }
        //</Script>

        //<Script>
        //Obtener todos los municipios de una Provincia
        public JsonResult GetMunicipiobyid(int id)
        {
            List<Municipio> municipios = new List<Municipio>();
            municipios = _context.Municipios.Where(Pro => Pro.Provincia.ProvinciaId == id).ToList();
            //list.Insert(0, new Municipio { MunicipioId = 0, Nombre = "Por favor Seleccione el Municipios" });
            return Json(new SelectList(municipios, "MunicipioId", "Nombre"));
        }
        //</Script>
    }
}