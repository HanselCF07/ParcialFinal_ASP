using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialFinal.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de emsamble")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Ensamble { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Color")]
        public String Color { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo")]
        public String Tipo { get; set; }
        [Required]
        //[StringLength(50)]
        [Display(Name = "Voltaje")]
        public int Voltaje { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Almacen")]
        public String Almacen { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Modelo")]
        public String Modelo { get; set; }
        [Required]
        //[StringLength(50)]
        [Display(Name = "Precio")]
        public Double Precio { get; set; }
    }
}