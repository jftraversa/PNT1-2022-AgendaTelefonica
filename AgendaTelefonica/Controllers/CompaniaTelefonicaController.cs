using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Controllers
{
    public class CompaniaTelefonicaController : Controller
    {
        private readonly AgendaDBContext _context;

        public CompaniaTelefonicaController(AgendaDBContext context)
        {
            _context = context;
        }

        // GET: CompaniaTelefonica
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompaniaTelefonica.ToListAsync());
        }

        // GET: CompaniaTelefonica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiaTelefonica = await _context.CompaniaTelefonica
                .FirstOrDefaultAsync(m => m.IdCompania == id);
            if (companiaTelefonica == null)
            {
                return NotFound();
            }

            return View(companiaTelefonica);
        }

        // GET: CompaniaTelefonica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompaniaTelefonica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompania,NombreCompania")] CompaniaTelefonica companiaTelefonica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companiaTelefonica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companiaTelefonica);
        }

        // GET: CompaniaTelefonica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiaTelefonica = await _context.CompaniaTelefonica.FindAsync(id);
            if (companiaTelefonica == null)
            {
                return NotFound();
            }
            return View(companiaTelefonica);
        }

        // POST: CompaniaTelefonica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdCompania,NombreCompania")] CompaniaTelefonica companiaTelefonica)
        {
            if (id != companiaTelefonica.IdCompania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companiaTelefonica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniaTelefonicaExists(companiaTelefonica.IdCompania))
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
            return View(companiaTelefonica);
        }

        // GET: CompaniaTelefonica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiaTelefonica = await _context.CompaniaTelefonica
                .FirstOrDefaultAsync(m => m.IdCompania == id);
            if (companiaTelefonica == null)
            {
                return NotFound();
            }

            return View(companiaTelefonica);
        }

        // POST: CompaniaTelefonica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var companiaTelefonica = await _context.CompaniaTelefonica.FindAsync(id);
            _context.CompaniaTelefonica.Remove(companiaTelefonica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompaniaTelefonicaExists(int? id)
        {
            return _context.CompaniaTelefonica.Any(e => e.IdCompania == id);
        }
    }
}
