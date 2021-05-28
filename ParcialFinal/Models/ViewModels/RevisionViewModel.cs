using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ParcialFinal.Models.ViewModels
{
    public class RevisionViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Client_Id")]
        public int Client_Id { get; set; }
        [Required]
        [Display(Name = "Empleado_Id")]
        public int Empleado_Id { get; set; }
        [Required]
        [Display(Name = "Producto_Id")]
        public int Producto_Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Observaciones")]
        public String Observaciones { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Revision")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Revision { get; set; }
    }
}