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
    public class INVENTARIO_MATERIALController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: INVENTARIO_MATERIAL
        public ActionResult Index()
        {
            var iNVENTARIO_MATERIAL = db.INVENTARIO_MATERIAL.Include(i => i.COMPRA);
            return View(iNVENTARIO_MATERIAL.ToList());
        }

        // GET: INVENTARIO_MATERIAL/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO_MATERIAL iNVENTARIO_MATERIAL = db.INVENTARIO_MATERIAL.Find(id);
            if (iNVENTARIO_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO_MATERIAL);
        }

        // GET: INVENTARIO_MATERIAL/Create
        public ActionResult Create()
        {
            ViewBag.CORRELATIVO = new SelectList(db.COMPRA, "CORRELATIVO", "ID_COSTO");
            return View();
        }

        // POST: INVENTARIO_MATERIAL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_MATERIAL,CORRELATIVO,NOM_MATERIAL,UNIDADES,EXISTENCIA_")] INVENTARIO_MATERIAL iNVENTARIO_MATERIAL)
        {
            if (ModelState.IsValid)
            {
                db.INVENTARIO_MATERIAL.Add(iNVENTARIO_MATERIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CORRELATIVO = new SelectList(db.COMPRA, "CORRELATIVO", "ID_COSTO", iNVENTARIO_MATERIAL.CORRELATIVO);
            return View(iNVENTARIO_MATERIAL);
        }

        // GET: INVENTARIO_MATERIAL/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO_MATERIAL iNVENTARIO_MATERIAL = db.INVENTARIO_MATERIAL.Find(id);
            if (iNVENTARIO_MATERIAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.CORRELATIVO = new SelectList(db.COMPRA, "CORRELATIVO", "ID_COSTO", iNVENTARIO_MATERIAL.CORRELATIVO);
            return View(iNVENTARIO_MATERIAL);
        }

        // POST: INVENTARIO_MATERIAL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_MATERIAL,CORRELATIVO,NOM_MATERIAL,UNIDADES,EXISTENCIA_")] INVENTARIO_MATERIAL iNVENTARIO_MATERIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTARIO_MATERIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CORRELATIVO = new SelectList(db.COMPRA, "CORRELATIVO", "ID_COSTO", iNVENTARIO_MATERIAL.CORRELATIVO);
            return View(iNVENTARIO_MATERIAL);
        }

        // GET: INVENTARIO_MATERIAL/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO_MATERIAL iNVENTARIO_MATERIAL = db.INVENTARIO_MATERIAL.Find(id);
            if (iNVENTARIO_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO_MATERIAL);
        }

        // POST: INVENTARIO_MATERIAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            INVENTARIO_MATERIAL iNVENTARIO_MATERIAL = db.INVENTARIO_MATERIAL.Find(id);
            db.INVENTARIO_MATERIAL.Remove(iNVENTARIO_MATERIAL);
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
