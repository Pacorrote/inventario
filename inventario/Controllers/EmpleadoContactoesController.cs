using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inventario;

namespace inventario.Controllers
{
    public class EmpleadoContactoesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: EmpleadoContactoes
        public ActionResult Index()
        {
            var empleadoContacto = db.EmpleadoContacto.Include(e => e.Contacto).Include(e => e.Empleado);
            return View(empleadoContacto.ToList());
        }

        // GET: EmpleadoContactoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoContacto empleadoContacto = db.EmpleadoContacto.Find(id);
            if (empleadoContacto == null)
            {
                return HttpNotFound();
            }
            return View(empleadoContacto);
        }

        // GET: EmpleadoContactoes/Create
        public ActionResult Create()
        {
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion");
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "IdEmp");
            return View();
        }

        // POST: EmpleadoContactoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmp,IdCon,Descripcion")] EmpleadoContacto empleadoContacto)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoContacto.Add(empleadoContacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", empleadoContacto.IdCon);
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "IdEmp", empleadoContacto.IdEmp);
            return View(empleadoContacto);
        }

        // GET: EmpleadoContactoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoContacto empleadoContacto = db.EmpleadoContacto.Find(id);
            if (empleadoContacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", empleadoContacto.IdCon);
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "IdEmp", empleadoContacto.IdEmp);
            return View(empleadoContacto);
        }

        // POST: EmpleadoContactoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmp,IdCon,Descripcion")] EmpleadoContacto empleadoContacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoContacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", empleadoContacto.IdCon);
            ViewBag.IdEmp = new SelectList(db.Empleado, "IdEmp", "IdEmp", empleadoContacto.IdEmp);
            return View(empleadoContacto);
        }

        // GET: EmpleadoContactoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoContacto empleadoContacto = db.EmpleadoContacto.Find(id);
            if (empleadoContacto == null)
            {
                return HttpNotFound();
            }
            return View(empleadoContacto);
        }

        // POST: EmpleadoContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoContacto empleadoContacto = db.EmpleadoContacto.Find(id);
            db.EmpleadoContacto.Remove(empleadoContacto);
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
