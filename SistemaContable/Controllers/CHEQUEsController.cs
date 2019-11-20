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
    public class CHEQUEsController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: CHEQUEs
        public ActionResult Index()
        {
            var cHEQUE = db.CHEQUE.Include(c => c.LINEA_DE_PLANILLA).Include(c => c.PROVEEDOR);
            return View(cHEQUE.ToList());
        }

        // GET: CHEQUEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHEQUE cHEQUE = db.CHEQUE.Find(id);
            if (cHEQUE == null)
            {
                return HttpNotFound();
            }
            return View(cHEQUE);
        }

        // GET: CHEQUEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA");
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR");
            return View();
        }

        // POST: CHEQUEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CORRELATIVO_CHEQUE,COD_PROVEEDOR,ID_LINEA,NOMBRE,CONCEPTO_CHEQUE,MONTO,ANULADO_CHEQUE")] CHEQUE cHEQUE)
        {
            if (ModelState.IsValid)
            {
                db.CHEQUE.Add(cHEQUE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", cHEQUE.ID_LINEA);
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR", cHEQUE.COD_PROVEEDOR);
            return View(cHEQUE);
        }

        // GET: CHEQUEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHEQUE cHEQUE = db.CHEQUE.Find(id);
            if (cHEQUE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", cHEQUE.ID_LINEA);
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR", cHEQUE.COD_PROVEEDOR);
            return View(cHEQUE);
        }

        // POST: CHEQUEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CORRELATIVO_CHEQUE,COD_PROVEEDOR,ID_LINEA,NOMBRE,CONCEPTO_CHEQUE,MONTO,ANULADO_CHEQUE")] CHEQUE cHEQUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHEQUE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", cHEQUE.ID_LINEA);
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR", cHEQUE.COD_PROVEEDOR);
            return View(cHEQUE);
        }

        // GET: CHEQUEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHEQUE cHEQUE = db.CHEQUE.Find(id);
            if (cHEQUE == null)
            {
                return HttpNotFound();
            }
            return View(cHEQUE);
        }

        // POST: CHEQUEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHEQUE cHEQUE = db.CHEQUE.Find(id);
            db.CHEQUE.Remove(cHEQUE);
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
