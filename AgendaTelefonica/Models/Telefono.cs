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

        [Required(ErrorMessage = "El campo del Código de Area es requerido")]
        [Display(Name = "Código de Area")]
        public int? CodigoArea { get; set; }

        [Required(ErrorMessage = "El campo del Prefijo es requerido")]       
        [Display(Name = "Prefijo")]
        public int? Prefijo { get; set; }

        [Required(ErrorMessage = "El campo del Número es requerido")]
        [Display(Name = "Número")]
        public int? Numero { get; set; }

        [NotMapped]
        public virtual Contacto FK_Contacto { get; set; }
    }
}
