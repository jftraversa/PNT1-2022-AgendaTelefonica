using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Models
{
    public partial class MasterTableAgenda
    {
        public List<Contacto> Contactos { get; set; }
        public List<Telefono> Telefonos { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Email> Correo { get; set; }
        public List<CompaniaTelefonica> Empresa { get; set; }
    }
}
