using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcialFinal.Models;
using ParcialFinal.Models.ViewModels;

namespace ParcialFinal.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListPersonaViewModel> lst;
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {
                lst = (from d in db.persona
                       select new ListPersonaViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Direccion = d.direccion,
                           Telefono = d.telefono,
                           Correo = d.correo,
                           Tipo = d.tipo,
                           Fecha_Nacimiento = d.fecha_nacimiento
                       }).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaPersona(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntitiesParcial db = new CrudEntitiesParcial())
                    {
                        var oTabla = new persona();
                        oTabla.id = model.Id;
                        oTabla.nombre = model.Nombre;
                        oTabla.direccion = model.Direccion;
                        oTabla.telefono = model.Telefono;
                        oTabla.correo = model.Correo;
                        oTabla.tipo = model.Tipo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;
                        db.persona.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Persona/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            PersonaViewModel model = new PersonaViewModel();
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {
                var oTabla = db.persona.Find(Id);
                model.Nombre = oTabla.nombre;                
                model.Direccion = oTabla.direccion;                
                model.Telefono = oTabla.telefono;
                model.Correo = oTabla.correo;
                model.Tipo = oTabla.tipo;
                model.Fecha_Nacimiento = oTabla.fecha_nacimiento;
                model.Id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarPersona(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntitiesParcial db = new CrudEntitiesParcial())
                    {
                        var oTabla = db.persona.Find(model.Id);
                        oTabla.nombre = model.Nombre;
                        oTabla.direccion = model.Direccion;
                        oTabla.telefono = model.Telefono;
                        oTabla.correo = model.Correo;
                        oTabla.tipo = model.Tipo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Persona/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {

                var oTabla = db.persona.Find(Id);
                db.persona.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Persona/");
        }


    }

}
