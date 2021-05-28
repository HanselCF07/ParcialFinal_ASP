using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialFinal.Models.ViewModels
{
    public class ListProductoViewModel
    {
        public int Id { get; set; }
        public String Nombre { get; set; }     
        public DateTime Fecha_Ensamble { get; set; }
        public String Color { get; set; }
        public String Tipo { get; set; }
        public int Voltaje { get; set; }
        public String Almacen { get; set; }
        public String Modelo { get; set; }
        public Double Precio { get; set; }
    }
}