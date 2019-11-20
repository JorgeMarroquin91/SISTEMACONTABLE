using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaContable.Models;

namespace SistemaContable.Controllers
{
    public class CATALOGO_DE_PRODUCTOController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: CATALOGO_DE_PRODUCTO
        public ActionResult Index()
        {
            return View(db.CATALOGO_DE_PRODUCTO.ToList());
        }

        // GET: CATALOGO_DE_PRODUCTO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_DE_PRODUCTO cATALOGO_DE_PRODUCTO = db.CATALOGO_DE_PRODUCTO.Find(id);
            if (cATALOGO_DE_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_DE_PRODUCTO);
        }

        // GET: CATALOGO_DE_PRODUCTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATALOGO_DE_PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,COSTO_,DESCRIPCION_PRODUCTO,PORCENTAJE_GANACIA")] CATALOGO_DE_PRODUCTO cATALOGO_DE_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.CATALOGO_DE_PRODUCTO.Add(cATALOGO_DE_PRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATALOGO_DE_PRODUCTO);
        }

        // GET: CATALOGO_DE_PRODUCTO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_DE_PRODUCTO cATALOGO_DE_PRODUCTO = db.CATALOGO_DE_PRODUCTO.Find(id);
            if (cATALOGO_DE_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_DE_PRODUCTO);
        }

        // POST: CATALOGO_DE_PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,COSTO_,DESCRIPCION_PRODUCTO,PORCENTAJE_GANACIA")] CATALOGO_DE_PRODUCTO cATALOGO_DE_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATALOGO_DE_PRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATALOGO_DE_PRODUCTO);
        }

        // GET: CATALOGO_DE_PRODUCTO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATALOGO_DE_PRODUCTO cATALOGO_DE_PRODUCTO = db.CATALOGO_DE_PRODUCTO.Find(id);
            if (cATALOGO_DE_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATALOGO_DE_PRODUCTO);
        }

        // POST: CATALOGO_DE_PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CATALOGO_DE_PRODUCTO cATALOGO_DE_PRODUCTO = db.CATALOGO_DE_PRODUCTO.Find(id);
            db.CATALOGO_DE_PRODUCTO.Remove(cATALOGO_DE_PRODUCTO);
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
