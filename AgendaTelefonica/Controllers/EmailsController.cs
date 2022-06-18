using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaTelefonica.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AgendaTelefonica.Controllers
{
    public class EmailsController : Controller
    {
        private readonly AgendaDBContext _context;

        public EmailsController(AgendaDBContext context)
        {
            _context = context;
        }

        // GET: Emails
        public async Task<IActionResult> Index()
        {
            ListaDeContactos();
            return View(await _context.Email.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.IdEmail == id);

            ListaDeContactos(email.IdContacto);

            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Emails/Create
        public IActionResult Create()
        {
            ListaDeContactos();
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmail,CorreoElectronico,IdContacto")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ListaDeContactos(email.IdContacto);
            return View(email);
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            ListaDeContactos(email.IdContacto);
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdEmail,CorreoElectronico,IdContacto")] Email email)
        {
            if (id != email.IdEmail)
            {
                return NotFound();
            }

            var emailToUpdate = await _context.Email.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    emailToUpdate.IdEmail = email.IdEmail;
                    emailToUpdate.IdContacto = email.IdContacto;
                    emailToUpdate.CorreoElectronico = email.CorreoElectronico;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.IdEmail))
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
            ListaDeContactos(emailToUpdate.IdContacto);
            return View(emailToUpdate);
        }

        // GET: Emails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.IdEmail == id);

            ListaDeContactos(email.IdContacto);

            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var email = await _context.Email.FindAsync(id);
            _context.Email.Remove(email);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailExists(int? id)
        {
            return _context.Email.Any(e => e.IdEmail == id);
        }

        private void ListaDeContactos(object contactoIndex = null)
        {
            var contactosQuery = from d in _context.Contacto
                                   orderby d.NombreCompleto
                                   select d;
            ViewBag.IdContacto = new SelectList(contactosQuery, "IdContacto", "NombreCompleto", contactoIndex);
        }
    }
}
