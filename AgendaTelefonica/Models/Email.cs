using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgendaTelefonica.Models
{
    public partial class Email
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int? IdEmail { get; set; }

        [Required(ErrorMessage = "El formato del correo electrónico es incorrecto")]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        public int IdContacto { get; set; }
    }
}
