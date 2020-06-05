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
    public class Contacto_ProveedorController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Contacto_Proveedor
        public ActionResult Index()
        {
            var contacto_Proveedor = db.Contacto_Proveedor.Include(c => c.Contacto).Include(c => c.Proveedor);
            return View(contacto_Proveedor.ToList());
        }

        // GET: Contacto_Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            if (contacto_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(contacto_Proveedor);
        }

        // GET: Contacto_Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion");
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre");
            return View();
        }

        // POST: Contacto_Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCon,IdProv,Descripcion")] Contacto_Proveedor contacto_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Contacto_Proveedor.Add(contacto_Proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", contacto_Proveedor.IdCon);
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre", contacto_Proveedor.IdProv);
            return View(contacto_Proveedor);
        }

        // GET: Contacto_Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            if (contacto_Proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", contacto_Proveedor.IdCon);
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre", contacto_Proveedor.IdProv);
            return View(contacto_Proveedor);
        }

        // POST: Contacto_Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCon,IdProv,Descripcion")] Contacto_Proveedor contacto_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto_Proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCon = new SelectList(db.Contacto, "IdCon", "Descripcion", contacto_Proveedor.IdCon);
            ViewBag.IdProv = new SelectList(db.Proveedor, "IdProv", "Nombre", contacto_Proveedor.IdProv);
            return View(contacto_Proveedor);
        }

        // GET: Contacto_Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            if (contacto_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(contacto_Proveedor);
        }

        // POST: Contacto_Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto_Proveedor contacto_Proveedor = db.Contacto_Proveedor.Find(id);
            db.Contacto_Proveedor.Remove(contacto_Proveedor);
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
