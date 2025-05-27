using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PATISAZON.Models
{
    public class Pedidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        [Required]
        [Display(Name ="Nombre del cliente")]
        public virtual string nombre_cliente { get; set; }
        [Required]
        [Display(Name = "Dirreccion del pedido")]
        public virtual string direccion_cliente { get; set; }
        [Required]
        [Display(Name = "Numero telefonico o de celular")]
        public virtual string telefono_celular { get; set; }
        [Required]
        [Display(Name ="Dia de entrega del pedido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime Date { get; set; }
        [Required]
        [Display(Name = "Cantidad y nombre de los platillos")]
        public virtual string nombre_cantidad_platillo { get; set; }
        [Required]
        [Display(Name ="Estado del pedido")]
        public virtual string estado_pedido { get; set; }
    }
}