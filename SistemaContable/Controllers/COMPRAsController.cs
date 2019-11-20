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
    public class COMPRAsController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: COMPRAs
        public ActionResult Index()
        {
            var cOMPRA = db.COMPRA.Include(c => c.PROVEEDOR).Include(c => c.COSTO_INDIRECTO).Include(c => c.COTOS_DE_MATERIAL);
            return View(cOMPRA.ToList());
        }

        // GET: COMPRAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // GET: COMPRAs/Create
        public ActionResult Create()
        {
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR");
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO");
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL");
            return View();
        }

        // POST: COMPRAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CORRELATIVO,ID_COSMATERIAL,ID_COSTO,COD_PROVEEDOR,TIPO_DOCU_COMPRA,TIPO_PAGO_COMPRA,FECHA_EMISION,CONCEPTO_COMPRA,TIPO_DE_PAGO,SUMA,IVA,TOTAL_COMPRA,COMPRA_EXENTAS,RETENCION_RENTA,BONIFICACIONES,RETENCION_DE_IVA")] COMPRA cOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.COMPRA.Add(cOMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR", cOMPRA.COD_PROVEEDOR);
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO", cOMPRA.ID_COSTO);
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL", cOMPRA.ID_COSMATERIAL);
            return View(cOMPRA);
        }

        // GET: COMPRAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR", cOMPRA.COD_PROVEEDOR);
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO", cOMPRA.ID_COSTO);
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL", cOMPRA.ID_COSMATERIAL);
            return View(cOMPRA);
        }

        // POST: COMPRAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CORRELATIVO,ID_COSMATERIAL,ID_COSTO,COD_PROVEEDOR,TIPO_DOCU_COMPRA,TIPO_PAGO_COMPRA,FECHA_EMISION,CONCEPTO_COMPRA,TIPO_DE_PAGO,SUMA,IVA,TOTAL_COMPRA,COMPRA_EXENTAS,RETENCION_RENTA,BONIFICACIONES,RETENCION_DE_IVA")] COMPRA cOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_PROVEEDOR = new SelectList(db.PROVEEDOR, "COD_PROVEEDOR", "NOM_PROVEEDOR", cOMPRA.COD_PROVEEDOR);
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO", cOMPRA.ID_COSTO);
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL", cOMPRA.ID_COSMATERIAL);
            return View(cOMPRA);
        }

        // GET: COMPRAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // POST: COMPRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPRA cOMPRA = db.COMPRA.Find(id);
            db.COMPRA.Remove(cOMPRA);
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
