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
    public class TRANSACCIONESController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: TRANSACCIONES
        public ActionResult Index()
        {
            var tRANSACCIONES = db.TRANSACCIONES.Include(t => t.CHEQUE).Include(t => t.CUENTA).Include(t => t.PERIODO).Include(t => t.PLANILLA);
            return View(tRANSACCIONES.ToList());
        }

        // GET: TRANSACCIONES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCIONES tRANSACCIONES = db.TRANSACCIONES.Find(id);
            if (tRANSACCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCIONES);
        }

        // GET: TRANSACCIONES/Create
        public ActionResult Create()
        {
            ViewBag.CORRELATIVO_CHEQUE = new SelectList(db.CHEQUE, "CORRELATIVO_CHEQUE", "ID_LINEA");
            ViewBag.COD_CUENTA = new SelectList(db.CUENTA, "COD_CUENTA", "NOM_CUENTA");
            ViewBag.NUMPERIODO = new SelectList(db.PERIODO, "NUMPERIODO", "NUMPERIODO");
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI");
            return View();
        }

        // POST: TRANSACCIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NUM_TRANSACCION,NUMPERIODO,COD_CUENTA,CORRELATIVO_CHEQUE,ID_PLANILLA,CONCEPTO,CUENTA_CARGADA,CUENTA_ABONAR,MONTO_ABONADO,MONTO_CARGADO")] TRANSACCIONES tRANSACCIONES)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACCIONES.Add(tRANSACCIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CORRELATIVO_CHEQUE = new SelectList(db.CHEQUE, "CORRELATIVO_CHEQUE", "ID_LINEA", tRANSACCIONES.CORRELATIVO_CHEQUE);
            ViewBag.COD_CUENTA = new SelectList(db.CUENTA, "COD_CUENTA", "NOM_CUENTA", tRANSACCIONES.COD_CUENTA);
            ViewBag.NUMPERIODO = new SelectList(db.PERIODO, "NUMPERIODO", "NUMPERIODO", tRANSACCIONES.NUMPERIODO);
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI", tRANSACCIONES.ID_PLANILLA);
            return View(tRANSACCIONES);
        }

        // GET: TRANSACCIONES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCIONES tRANSACCIONES = db.TRANSACCIONES.Find(id);
            if (tRANSACCIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.CORRELATIVO_CHEQUE = new SelectList(db.CHEQUE, "CORRELATIVO_CHEQUE", "ID_LINEA", tRANSACCIONES.CORRELATIVO_CHEQUE);
            ViewBag.COD_CUENTA = new SelectList(db.CUENTA, "COD_CUENTA", "NOM_CUENTA", tRANSACCIONES.COD_CUENTA);
            ViewBag.NUMPERIODO = new SelectList(db.PERIODO, "NUMPERIODO", "NUMPERIODO", tRANSACCIONES.NUMPERIODO);
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI", tRANSACCIONES.ID_PLANILLA);
            return View(tRANSACCIONES);
        }

        // POST: TRANSACCIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NUM_TRANSACCION,NUMPERIODO,COD_CUENTA,CORRELATIVO_CHEQUE,ID_PLANILLA,CONCEPTO,CUENTA_CARGADA,CUENTA_ABONAR,MONTO_ABONADO,MONTO_CARGADO")] TRANSACCIONES tRANSACCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSACCIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CORRELATIVO_CHEQUE = new SelectList(db.CHEQUE, "CORRELATIVO_CHEQUE", "ID_LINEA", tRANSACCIONES.CORRELATIVO_CHEQUE);
            ViewBag.COD_CUENTA = new SelectList(db.CUENTA, "COD_CUENTA", "NOM_CUENTA", tRANSACCIONES.COD_CUENTA);
            ViewBag.NUMPERIODO = new SelectList(db.PERIODO, "NUMPERIODO", "NUMPERIODO", tRANSACCIONES.NUMPERIODO);
            ViewBag.ID_PLANILLA = new SelectList(db.PLANILLA, "ID_PLANILLA", "DUI", tRANSACCIONES.ID_PLANILLA);
            return View(tRANSACCIONES);
        }

        // GET: TRANSACCIONES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCIONES tRANSACCIONES = db.TRANSACCIONES.Find(id);
            if (tRANSACCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCIONES);
        }

        // POST: TRANSACCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TRANSACCIONES tRANSACCIONES = db.TRANSACCIONES.Find(id);
            db.TRANSACCIONES.Remove(tRANSACCIONES);
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
