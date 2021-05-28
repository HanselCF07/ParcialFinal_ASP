using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcialFinal.Models;
using ParcialFinal.Models.ViewModels;

namespace ParcialFinal.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListProductoViewModel> lst;
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {
                lst = (from d in db.producto
                       select new ListProductoViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Fecha_Ensamble = d.fecha_ensamble,
                           Color = d.color,
                           Tipo = d.tipo,
                           Voltaje = d.voltaje,
                           Almacen = d.almacen,
                           Modelo = d.modelo,
                           Precio = d.precio
                       }).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntitiesParcial db = new CrudEntitiesParcial())
                    {
                        var oTabla = new producto();
                        oTabla.nombre = model.Nombre;
                        oTabla.fecha_ensamble = model.Fecha_Ensamble;
                        oTabla.color = model.Color;
                        oTabla.tipo = model.Tipo;
                        oTabla.voltaje = model.Voltaje;
                        oTabla.almacen = model.Almacen;
                        oTabla.modelo = model.Modelo;
                        oTabla.precio = model.Precio;

                        db.producto.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
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
            ProductoViewModel model = new ProductoViewModel();
            using (CrudEntitiesParcial db = new CrudEntitiesParcial())
            {
                var oTabla = db.producto.Find(Id);
                model.Nombre = oTabla.nombre;
                model.Fecha_Ensamble = oTabla.fecha_ensamble;
                model.Color = oTabla.color;
                model.Tipo = oTabla.tipo;
                model.Voltaje = oTabla.voltaje;
                model.Almacen = oTabla.almacen;
                model.Modelo = oTabla.modelo;
                model.Precio = oTabla.precio;
                model.Id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntitiesParcial db = new CrudEntitiesParcial())
                    {
                        var oTabla = db.producto.Find(model.Id);
                        oTabla.nombre = model.Nombre;
                        oTabla.fecha_ensamble = model.Fecha_Ensamble;
                        oTabla.color = model.Color;
                        oTabla.tipo = model.Tipo;
                        oTabla.voltaje = model.Voltaje;
                        oTabla.almacen = model.Almacen;
                        oTabla.modelo = model.Modelo;
                        oTabla.precio = model.Precio;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
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

                var oTabla = db.producto.Find(Id);
                db.producto.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Producto/");
        }


    }

}
