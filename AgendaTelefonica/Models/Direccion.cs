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

        [Required(ErrorMessage = "El campo de la dirección es requerido")]
        [Display(Name = "Dirección (Calles)")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo de la altura es requerido")]
        [Display(Name = "Altura")]
        public int? AlturaCalle { get; set; }

        [Required(ErrorMessage = "El campo del código postal es requerido")]
        [Display(Name = "Código Postal")]
        public int? CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo de la Localidad es requerido")]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El campo de la Provincia es requerido")]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [NotMapped]
        public virtual Contacto FK_Contacto { get; set; }
    }
}
