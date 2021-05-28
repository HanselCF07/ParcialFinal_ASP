using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcialFinal.Models;
using ParcialFinal.Models.ViewModels;

namespace ParcialFinal.Controllers
{
    public class RevisionController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListRevisionViewModel> lst;
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {
                lst = (from d in db.revision
                       select new ListRevisionViewModel
                       {
                           Id = d.id,
                           Cliente_Id = d.cliente_id,
                           Empleado_Id = d.empleado_id,
                           Producto_Id = d.producto_id,
                           Observaciones = d.observaciones,
                           Fecha_Revision = d.fecha_revision
                       }).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaRevision(RevisionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntitiesParcial db = new CrudEntitiesParcial())
                    {
                        var oTabla = new revision();                        
                        oTabla.cliente_id = model.Client_Id;
                        oTabla.empleado_id = model.Empleado_Id;
                        oTabla.producto_id = model.Producto_Id;
                        oTabla.observaciones = model.Observaciones;
                        oTabla.fecha_revision = model.Fecha_Revision;
                        db.revision.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Revision/");
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
            RevisionViewModel model = new RevisionViewModel();
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {
                var oTabla = db.revision.Find(Id);
                model.Client_Id = oTabla.cliente_id;                
                model.Empleado_Id = oTabla.empleado_id;                
                model.Producto_Id = oTabla.producto_id;
                model.Observaciones = oTabla.observaciones;
                model.Fecha_Revision = oTabla.fecha_revision;
                model.Id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarRevision(RevisionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntitiesParcial db = new CrudEntitiesParcial())
                    {
                        var oTabla = db.revision.Find(model.Id);
                        oTabla.cliente_id = model.Client_Id;
                        oTabla.empleado_id = model.Empleado_Id;
                        oTabla.producto_id = model.Producto_Id;
                        oTabla.observaciones = model.Observaciones;
                        oTabla.fecha_revision = model.Fecha_Revision;
                       
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Revision/");
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

                var oTabla = db.revision.Find(Id);
                db.revision.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Revision/");
        }


    }

}
