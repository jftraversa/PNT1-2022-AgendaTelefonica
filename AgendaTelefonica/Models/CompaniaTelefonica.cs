using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgendaTelefonica.Models
{
    public partial class CompaniaTelefonica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int? IdCompania { get; set; }

        [Required]
        [Display(Name = "Compañia Telefonica")]
        public string NombreCompania { get; set; }

        public virtual Telefono FK_Telefono { get; set; }
    }
}
