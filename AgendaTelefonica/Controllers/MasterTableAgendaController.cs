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
    public class MasterTableAgendaController : Controller
    {
        private readonly AgendaDBContext _context;

        public MasterTableAgendaController(AgendaDBContext context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            MasterTableAgenda parent = new MasterTableAgenda();

            var contactos = from s in _context.Contacto
                            select s;
            parent.Contactos = contactos.ToList();

            var telefonos = from s in _context.Telefono
                            select s;
            parent.Telefonos = telefonos.ToList();

            var direccion = from s in _context.Direccion
                            select s;
            parent.Direcciones = direccion.ToList();

            var correo = from s in _context.Email
                         select s;
            parent.Correo = correo.ToList();

            var empresa = from s in _context.CompaniaTelefonica
                          select s;

            parent.Empresa = empresa.ToList();

            List<MasterTableAgenda> lista = new List<MasterTableAgenda>();
            lista.Add(parent);

            return View(lista.AsEnumerable());
        }
    }
}
