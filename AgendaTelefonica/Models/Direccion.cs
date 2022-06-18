using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgendaTelefonica.Models
{
    public partial class Direccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int? IdDireccion { get; set; }
        public int? IdContacto { get; set; }

        [Required]
        [Display(Name = "Dirección (Calles)")]
        public string Calle { get; set; }

        [Required]
        [Display(Name = "Altura")]
        public int? AlturaCalle { get; set; }

        [Required]
        [Display(Name = "Código Postal")]
        public int? CodigoPostal { get; set; }

        [Required]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
    }
}
