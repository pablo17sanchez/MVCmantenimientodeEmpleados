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
    public class Empleado_DetallesController : Controller
    {
        private EmpleadosEDMEntities db = new EmpleadosEDMEntities();

        // GET: Empleado_Detalles
        public ActionResult Index()
        {
            var empleado_Detalles = db.Empleado_Detalles.Include(e => e.Empleado);
            return View(empleado_Detalles.ToList());
        }

        // GET: Empleado_Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Detalles empleado_Detalles = db.Empleado_Detalles.Find(id);
            if (empleado_Detalles == null)
            {
                return HttpNotFound();
            }
            return View(empleado_Detalles);
        }

        // GET: Empleado_Detalles/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre");
            return View();
        }

        // POST: Empleado_Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Detalles_ID,Empleado_ID,Categoria,ANTIGUEDAD_Pluses,Experiencia_Anios,Salario")] Empleado_Detalles empleado_Detalles)
        {
            if (ModelState.IsValid)
            {
                db.Empleado_Detalles.Add(empleado_Detalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre", empleado_Detalles.Empleado_ID);
            return View(empleado_Detalles);
        }

        // GET: Empleado_Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Detalles empleado_Detalles = db.Empleado_Detalles.Find(id);
            if (empleado_Detalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre", empleado_Detalles.Empleado_ID);
            return View(empleado_Detalles);
        }

        // POST: Empleado_Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Detalles_ID,Empleado_ID,Categoria,ANTIGUEDAD_Pluses,Experiencia_Anios,Salario")] Empleado_Detalles empleado_Detalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado_Detalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID", "Nombre", empleado_Detalles.Empleado_ID);
            return View(empleado_Detalles);
        }

        // GET: Empleado_Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Detalles empleado_Detalles = db.Empleado_Detalles.Find(id);
            if (empleado_Detalles == null)
            {
                return HttpNotFound();
            }
            return View(empleado_Detalles);
        }

        // POST: Empleado_Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado_Detalles empleado_Detalles = db.Empleado_Detalles.Find(id);
            db.Empleado_Detalles.Remove(empleado_Detalles);
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
