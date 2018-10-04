using EjercicioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioMVC.Controllers
{
    public class ProveedorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (BD_EjercicioEntities db = new BD_EjercicioEntities())
            {
                return View(db.Proveedor.ToList());
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proveedor p)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                using (BD_EjercicioEntities db = new BD_EjercicioEntities())
                {
                    db.Proveedor.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Compruebe que RUT no haya sido ingresado");
                return View();
            }

        }

        [HttpGet]
        public ActionResult delete(string rutProveedor)
        {
            using (BD_EjercicioEntities db = new BD_EjercicioEntities())
            {
                try
                {
                    Proveedor p = db.Proveedor.Find(rutProveedor);
                    db.Proveedor.Remove(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Compruebe que no existen productos que dependan de este Proveedor." + ex.Message);
                    return RedirectToAction("Index");
                }

            }
        }

        [HttpGet]
        public ActionResult Edit(string rutProveedor)
        {
            using (BD_EjercicioEntities db = new BD_EjercicioEntities())
            {
                Proveedor p = db.Proveedor.Find(rutProveedor);
                return View(p);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proveedor p)
        {
            using (BD_EjercicioEntities db = new BD_EjercicioEntities())
            {
                Proveedor pAux = db.Proveedor.Find(p.rutProveedor);
                pAux.nombre = p.nombre;
                pAux.telefono = p.telefono;
                pAux.paginaWeb = p.paginaWeb;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}