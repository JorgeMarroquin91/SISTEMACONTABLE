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
    public class REMESASController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: REMESAS
        public ActionResult Index()
        {
            var rEMESAS = db.REMESAS.Include(r => r.VENTA);
            return View(rEMESAS.ToList());
        }

        // GET: REMESAS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REMESAS rEMESAS = db.REMESAS.Find(id);
            if (rEMESAS == null)
            {
                return HttpNotFound();
            }
            return View(rEMESAS);
        }

        // GET: REMESAS/Create
        public ActionResult Create()
        {
            ViewBag.CORRELATIVO_DOC = new SelectList(db.VENTA, "CORRELATIVO_DOC", "ID_PRODUCTO");
            return View();
        }

        // POST: REMESAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CORRELATIVO_CHEQUE_REMESA,CORRELATIVO_DOC,A_NOMBRE,CONCEPTO_REMESA,MONTO_REMESA,ANULADO_REMESA")] REMESAS rEMESAS)
        {
            if (ModelState.IsValid)
            {
                db.REMESAS.Add(rEMESAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CORRELATIVO_DOC = new SelectList(db.VENTA, "CORRELATIVO_DOC", "ID_PRODUCTO", rEMESAS.CORRELATIVO_DOC);
            return View(rEMESAS);
        }

        // GET: REMESAS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REMESAS rEMESAS = db.REMESAS.Find(id);
            if (rEMESAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CORRELATIVO_DOC = new SelectList(db.VENTA, "CORRELATIVO_DOC", "ID_PRODUCTO", rEMESAS.CORRELATIVO_DOC);
            return View(rEMESAS);
        }

        // POST: REMESAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CORRELATIVO_CHEQUE_REMESA,CORRELATIVO_DOC,A_NOMBRE,CONCEPTO_REMESA,MONTO_REMESA,ANULADO_REMESA")] REMESAS rEMESAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEMESAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CORRELATIVO_DOC = new SelectList(db.VENTA, "CORRELATIVO_DOC", "ID_PRODUCTO", rEMESAS.CORRELATIVO_DOC);
            return View(rEMESAS);
        }

        // GET: REMESAS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REMESAS rEMESAS = db.REMESAS.Find(id);
            if (rEMESAS == null)
            {
                return HttpNotFound();
            }
            return View(rEMESAS);
        }

        // POST: REMESAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            REMESAS rEMESAS = db.REMESAS.Find(id);
            db.REMESAS.Remove(rEMESAS);
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
