using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpleadosEDM.Models;

namespace EmpleadosEDM.Controllers
{
    public class Empleados_Antiguedad_EstadisticasController : Controller
    {
        private EmpleadosEDMEntities db = new EmpleadosEDMEntities();

        // GET: Empleados_Antiguedad_Estadisticas
        public ActionResult Index()
        {
            var empleados_Antiguedad_Estadisticas = db.Empleados_Antiguedad_Estadisticas.Include(e => e.Empleado);
            return View(empleados_Antiguedad_Estadisticas.ToList());
        }

        // GET: Empleados_Antiguedad_Estadisticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados_Antiguedad_Estadisticas empleados_Antiguedad_Estadisticas = db.Empleados_Antiguedad_Estadisticas.Find(id);
            if (empleados_Antiguedad_Estadisticas == null)
            {
                return HttpNotFound();
            }
            return View(empleados_Antiguedad_Estadisticas);
        }

        // GET: Empleados_Antiguedad_Estadisticas/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre");
            return View();
        }

        // POST: Empleados_Antiguedad_Estadisticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ANTIGUEDAD_ID,Empleado_ID,Nombre,Extra,Bajas_Laborales")] Empleados_Antiguedad_Estadisticas empleados_Antiguedad_Estadisticas)
        {
            if (ModelState.IsValid)
            {
                db.Empleados_Antiguedad_Estadisticas.Add(empleados_Antiguedad_Estadisticas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre", empleados_Antiguedad_Estadisticas.Empleado_ID);
            return View(empleados_Antiguedad_Estadisticas);
        }

        // GET: Empleados_Antiguedad_Estadisticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados_Antiguedad_Estadisticas empleados_Antiguedad_Estadisticas = db.Empleados_Antiguedad_Estadisticas.Find(id);
            if (empleados_Antiguedad_Estadisticas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre", empleados_Antiguedad_Estadisticas.Empleado_ID);
            return View(empleados_Antiguedad_Estadisticas);
        }

        // POST: Empleados_Antiguedad_Estadisticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ANTIGUEDAD_ID,Empleado_ID,Nombre,Extra,Bajas_Laborales")] Empleados_Antiguedad_Estadisticas empleados_Antiguedad_Estadisticas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados_Antiguedad_Estadisticas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre", empleados_Antiguedad_Estadisticas.Empleado_ID);
            return View(empleados_Antiguedad_Estadisticas);
        }

        // GET: Empleados_Antiguedad_Estadisticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados_Antiguedad_Estadisticas empleados_Antiguedad_Estadisticas = db.Empleados_Antiguedad_Estadisticas.Find(id);
            if (empleados_Antiguedad_Estadisticas == null)
            {
                return HttpNotFound();
            }
            return View(empleados_Antiguedad_Estadisticas);
        }

        // POST: Empleados_Antiguedad_Estadisticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados_Antiguedad_Estadisticas empleados_Antiguedad_Estadisticas = db.Empleados_Antiguedad_Estadisticas.Find(id);
            db.Empleados_Antiguedad_Estadisticas.Remove(empleados_Antiguedad_Estadisticas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
