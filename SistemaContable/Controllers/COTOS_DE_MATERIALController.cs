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
    public class COTOS_DE_MATERIALController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: COTOS_DE_MATERIAL
        public ActionResult Index()
        {
            return View(db.COTOS_DE_MATERIAL.ToList());
        }

        // GET: COTOS_DE_MATERIAL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COTOS_DE_MATERIAL cOTOS_DE_MATERIAL = db.COTOS_DE_MATERIAL.Find(id);
            if (cOTOS_DE_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(cOTOS_DE_MATERIAL);
        }

        // GET: COTOS_DE_MATERIAL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COTOS_DE_MATERIAL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COSMATERIAL,FECHA_DE_INGRESO,COSTO_DE_COMPRA,COSTO_UNITARIO")] COTOS_DE_MATERIAL cOTOS_DE_MATERIAL)
        {
            if (ModelState.IsValid)
            {
                db.COTOS_DE_MATERIAL.Add(cOTOS_DE_MATERIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOTOS_DE_MATERIAL);
        }

        // GET: COTOS_DE_MATERIAL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COTOS_DE_MATERIAL cOTOS_DE_MATERIAL = db.COTOS_DE_MATERIAL.Find(id);
            if (cOTOS_DE_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(cOTOS_DE_MATERIAL);
        }

        // POST: COTOS_DE_MATERIAL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COSMATERIAL,FECHA_DE_INGRESO,COSTO_DE_COMPRA,COSTO_UNITARIO")] COTOS_DE_MATERIAL cOTOS_DE_MATERIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOTOS_DE_MATERIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOTOS_DE_MATERIAL);
        }

        // GET: COTOS_DE_MATERIAL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COTOS_DE_MATERIAL cOTOS_DE_MATERIAL = db.COTOS_DE_MATERIAL.Find(id);
            if (cOTOS_DE_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(cOTOS_DE_MATERIAL);
        }

        // POST: COTOS_DE_MATERIAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COTOS_DE_MATERIAL cOTOS_DE_MATERIAL = db.COTOS_DE_MATERIAL.Find(id);
            db.COTOS_DE_MATERIAL.Remove(cOTOS_DE_MATERIAL);
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
