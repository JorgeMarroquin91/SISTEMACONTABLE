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
    public class COSTO_INDIRECTOController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: COSTO_INDIRECTO
        public ActionResult Index()
        {
            var cOSTO_INDIRECTO = db.COSTO_INDIRECTO.Include(c => c.PLANILLA);
            return View(cOSTO_INDIRECTO.ToList());
        }

        // GET: COSTO_INDIRECTO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSTO_INDIRECTO cOSTO_INDIRECTO = db.COSTO_INDIRECTO.Find(id);
            if (cOSTO_INDIRECTO == null)
            {
                return HttpNotFound();
            }
            return View(cOSTO_INDIRECTO);
        }

        // GET: COSTO_INDIRECTO/Create
        public ActionResult Create()
        {
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI");
            return View();
        }

        // POST: COSTO_INDIRECTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COSTO,ID_PLANILLA,COSTO_DE_MANO,OTROS_COSTOS")] COSTO_INDIRECTO cOSTO_INDIRECTO)
        {
            if (ModelState.IsValid)
            {
                db.COSTO_INDIRECTO.Add(cOSTO_INDIRECTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI", cOSTO_INDIRECTO.ID_PLANILLA);
            return View(cOSTO_INDIRECTO);
        }

        // GET: COSTO_INDIRECTO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSTO_INDIRECTO cOSTO_INDIRECTO = db.COSTO_INDIRECTO.Find(id);
            if (cOSTO_INDIRECTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI", cOSTO_INDIRECTO.ID_PLANILLA);
            return View(cOSTO_INDIRECTO);
        }

        // POST: COSTO_INDIRECTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COSTO,ID_PLANILLA,COSTO_DE_MANO,OTROS_COSTOS")] COSTO_INDIRECTO cOSTO_INDIRECTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOSTO_INDIRECTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI", cOSTO_INDIRECTO.ID_PLANILLA);
            return View(cOSTO_INDIRECTO);
        }

        // GET: COSTO_INDIRECTO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSTO_INDIRECTO cOSTO_INDIRECTO = db.COSTO_INDIRECTO.Find(id);
            if (cOSTO_INDIRECTO == null)
            {
                return HttpNotFound();
            }
            return View(cOSTO_INDIRECTO);
        }

        // POST: COSTO_INDIRECTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COSTO_INDIRECTO cOSTO_INDIRECTO = db.COSTO_INDIRECTO.Find(id);
            db.COSTO_INDIRECTO.Remove(cOSTO_INDIRECTO);
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
