using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PATISAZON.Models
{
    [Table("Platillos")]
    public partial class Platillos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }

        [Required]
        [Display(Name = "Platillo")]
        public virtual string nombre_platillo { get; set; }

        [Required]
        [Url]
        [Display(Name = "Foto del Platillo")]
        public virtual string foto_platillo { get; set; }

        [Required]
        [Display(Name = "Descripcion del platillo")]
        public virtual string descripcion_platillo { get; set; }

        [Required]
        [Display(Name = "Precio del Platillo")]
        public virtual int precio_platillo { get; set; }

        [Display(Name = "Dia de la semana")]
        public virtual string categoria { get; set; }

    }
}