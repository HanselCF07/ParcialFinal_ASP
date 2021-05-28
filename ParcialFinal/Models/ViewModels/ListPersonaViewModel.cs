using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialFinal.Models.ViewModels
{
    public class ListPersonaViewModel
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }
        public int Tipo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
    }
}