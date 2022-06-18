using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgendaTelefonica.Models
{
    public partial class Telefono
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int? IdTelefono { get; set; }
        public int? IdContacto { get; set; }

        [Display(Name = "Empresa")]
        public int? IdCompania { get; set; }

        [Required]
        [Display(Name = "Código de Area")]
        public int? CodigoArea { get; set; }

        [Required]
        [Display(Name = "Prefijo")]
        public int? Prefijo { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int? Numero { get; set; }
    }
}
