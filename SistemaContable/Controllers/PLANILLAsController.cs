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
    public class PLANILLAsController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: PLANILLAs
        public ActionResult Index()
        {
            var pLANILLA = db.PLANILLA.Include(p => p.EMPLEADO).Include(p => p.HOJA_DE_TRABAJO).Include(p => p.LINEA_DE_PLANILLA);
            return View(pLANILLA.ToList());
        }

        // GET: PLANILLAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Create
        public ActionResult Create()
        {
            ViewBag.DUI = new SelectList(db.EMPLEADO, "DUI", "NOMBRE");
            ViewBag.ID_HOJA = new SelectList(db.HOJA_DE_TRABAJO, "ID_HOJA", "ID_HOJA");
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA");
            return View();
        }

        // POST: PLANILLAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PLANILLA,DUI,ID_LINEA,ID_HOJA,FECHAPAGO,DE_ISS_TRABA,DESCUENTOS,AFP_TRABAJADOR,TOTAL_PLANILLA")] PLANILLA pLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.PLANILLA.Add(pLANILLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DUI = new SelectList(db.EMPLEADO, "DUI", "NOMBRE", pLANILLA.DUI);
            ViewBag.ID_HOJA = new SelectList(db.HOJA_DE_TRABAJO, "ID_HOJA", "ID_HOJA", pLANILLA.ID_HOJA);
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", pLANILLA.ID_LINEA);
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            ViewBag.DUI = new SelectList(db.EMPLEADO, "DUI", "NOMBRE", pLANILLA.DUI);
            ViewBag.ID_HOJA = new SelectList(db.HOJA_DE_TRABAJO, "ID_HOJA", "ID_HOJA", pLANILLA.ID_HOJA);
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", pLANILLA.ID_LINEA);
            return View(pLANILLA);
        }

        // POST: PLANILLAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PLANILLA,DUI,ID_LINEA,ID_HOJA,FECHAPAGO,DE_ISS_TRABA,DESCUENTOS,AFP_TRABAJADOR,TOTAL_PLANILLA")] PLANILLA pLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLANILLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DUI = new SelectList(db.EMPLEADO, "DUI", "NOMBRE", pLANILLA.DUI);
            ViewBag.ID_HOJA = new SelectList(db.HOJA_DE_TRABAJO, "ID_HOJA", "ID_HOJA", pLANILLA.ID_HOJA);
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", pLANILLA.ID_LINEA);
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // POST: PLANILLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLANILLA pLANILLA = db.PLANILLA.Find(id);
            db.PLANILLA.Remove(pLANILLA);
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
