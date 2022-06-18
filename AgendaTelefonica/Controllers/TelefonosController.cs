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
    public class TelefonosController : Controller
    {
        private readonly AgendaDBContext _context;

        public TelefonosController(AgendaDBContext context)
        {
            _context = context;
        }

        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            ListaDeContactos();
            ListaDeEmpresas();
            return View(await _context.Telefono.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .FirstOrDefaultAsync(m => m.IdTelefono == id);

            ListaDeContactos(telefono.IdContacto);
            ListaDeEmpresas(telefono.IdCompania);

            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            ListaDeContactos();
            ListaDeEmpresas();
            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefono,IdContacto,IdCompania,CodigoArea,Prefijo,Numero")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ListaDeContactos(telefono.IdContacto);
            ListaDeEmpresas(telefono.IdCompania);
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono.FindAsync(id);

            ListaDeContactos(telefono.IdContacto);
            ListaDeEmpresas(telefono.IdCompania);

            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdTelefono,IdContacto,IdCompania,CodigoArea,Prefijo,Numero")] Telefono telefono)
        {
            if (id != telefono.IdTelefono)
            {
                return NotFound();
            }

            var telefonoToUpdate = await _context.Telefono.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    telefonoToUpdate.IdContacto = telefono.IdContacto;
                    telefonoToUpdate.IdCompania = telefono.IdCompania;
                    telefonoToUpdate.IdTelefono = telefono.IdTelefono;
                    telefonoToUpdate.CodigoArea = telefono.CodigoArea;
                    telefonoToUpdate.Prefijo = telefono.Prefijo;
                    telefonoToUpdate.Numero = telefono.Numero;

                    _context.Update(telefonoToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.IdTelefono))
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
            ListaDeContactos(telefonoToUpdate.IdContacto);
            ListaDeEmpresas(telefonoToUpdate.IdCompania);
            return View(telefonoToUpdate);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefono
                .FirstOrDefaultAsync(m => m.IdTelefono == id);

            ListaDeContactos(telefono.IdContacto);
            ListaDeEmpresas(telefono.IdCompania);

            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var telefono = await _context.Telefono.FindAsync(id);
            _context.Telefono.Remove(telefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int? id)
        {
            return _context.Telefono.Any(e => e.IdTelefono == id);
        }

        private void ListaDeContactos(object contactoIndex = null)
        {
            var contactosQuery = from d in _context.Contacto
                                 orderby d.NombreCompleto
                                 select d;
            ViewBag.IdContacto = new SelectList(contactosQuery, "IdContacto", "NombreCompleto", contactoIndex);
        }

        private void ListaDeEmpresas(object empresaIndex = null)
        {
            var contactosQuery = from d in _context.CompaniaTelefonica
                                 orderby d.NombreCompania
                                 select d;
            ViewBag.IdCompania = new SelectList(contactosQuery, "IdCompania", "NombreCompania", empresaIndex);
        }
    }
}
