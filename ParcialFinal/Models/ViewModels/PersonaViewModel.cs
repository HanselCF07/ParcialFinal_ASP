using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ParcialFinal.Models.ViewModels
{
    public class PersonaViewModel
    {
        [Required]
        //[StringLength(50)]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Direccion")]
        public String Direccion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Telefono")]
        public String Telefono { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Correo")]
        public String Correo { get; set; }
        [Required]
        //[StringLength(50)]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }      
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}