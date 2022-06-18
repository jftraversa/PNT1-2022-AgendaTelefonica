using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgendaTelefonica.Models
{
    public partial class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdContacto { get; set; }

        public int? IdAgenda { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        public int IdTelefono { get; set; }
    }
}
