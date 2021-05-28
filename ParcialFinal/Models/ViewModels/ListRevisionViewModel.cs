using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialFinal.Models.ViewModels
{
    public class ListRevisionViewModel
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public int Empleado_Id { get; set; }
        public int Producto_Id { get; set; }
        public String Observaciones { get; set; }
        public DateTime Fecha_Revision { get; set; }
    }
}