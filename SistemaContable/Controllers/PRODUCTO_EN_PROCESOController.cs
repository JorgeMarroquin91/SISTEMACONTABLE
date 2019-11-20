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
    public class PRODUCTO_EN_PROCESOController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: PRODUCTO_EN_PROCESO
        public ActionResult Index()
        {
            var pRODUCTO_EN_PROCESO = db.PRODUCTO_EN_PROCESO.Include(p => p.CATALOGO_DE_PRODUCTO);
            return View(pRODUCTO_EN_PROCESO.ToList());
        }

        // GET: PRODUCTO_EN_PROCESO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_EN_PROCESO pRODUCTO_EN_PROCESO = db.PRODUCTO_EN_PROCESO.Find(id);
            if (pRODUCTO_EN_PROCESO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO_EN_PROCESO);
        }

        // GET: PRODUCTO_EN_PROCESO/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO");
            return View();
        }

        // POST: PRODUCTO_EN_PROCESO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CORRELATIVO_PROCE,ID_PRODUCTO,FECHA_DE_INICIO,FECHA_DE_DESPACHO,CANTI_PROCESO")] PRODUCTO_EN_PROCESO pRODUCTO_EN_PROCESO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO_EN_PROCESO.Add(pRODUCTO_EN_PROCESO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO", pRODUCTO_EN_PROCESO.ID_PRODUCTO);
            return View(pRODUCTO_EN_PROCESO);
        }

        // GET: PRODUCTO_EN_PROCESO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_EN_PROCESO pRODUCTO_EN_PROCESO = db.PRODUCTO_EN_PROCESO.Find(id);
            if (pRODUCTO_EN_PROCESO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO", pRODUCTO_EN_PROCESO.ID_PRODUCTO);
            return View(pRODUCTO_EN_PROCESO);
        }

        // POST: PRODUCTO_EN_PROCESO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CORRELATIVO_PROCE,ID_PRODUCTO,FECHA_DE_INICIO,FECHA_DE_DESPACHO,CANTI_PROCESO")] PRODUCTO_EN_PROCESO pRODUCTO_EN_PROCESO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO_EN_PROCESO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO", pRODUCTO_EN_PROCESO.ID_PRODUCTO);
            return View(pRODUCTO_EN_PROCESO);
        }

        // GET: PRODUCTO_EN_PROCESO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_EN_PROCESO pRODUCTO_EN_PROCESO = db.PRODUCTO_EN_PROCESO.Find(id);
            if (pRODUCTO_EN_PROCESO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO_EN_PROCESO);
        }

        // POST: PRODUCTO_EN_PROCESO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCTO_EN_PROCESO pRODUCTO_EN_PROCESO = db.PRODUCTO_EN_PROCESO.Find(id);
            db.PRODUCTO_EN_PROCESO.Remove(pRODUCTO_EN_PROCESO);
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
