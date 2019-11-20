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
    public class KARDEXesController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: KARDEXes
        public ActionResult Index()
        {
            return View(db.KARDEX.ToList());
        }

        // GET: KARDEXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARDEX kARDEX = db.KARDEX.Find(id);
            if (kARDEX == null)
            {
                return HttpNotFound();
            }
            return View(kARDEX);
        }

        // GET: KARDEXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KARDEXes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NUMKARDEX,COSTOUNITARIO,FECHA_INGRESO,FECHA_DE_SALIDA")] KARDEX kARDEX)
        {
            if (ModelState.IsValid)
            {
                db.KARDEX.Add(kARDEX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kARDEX);
        }

        // GET: KARDEXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARDEX kARDEX = db.KARDEX.Find(id);
            if (kARDEX == null)
            {
                return HttpNotFound();
            }
            return View(kARDEX);
        }

        // POST: KARDEXes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NUMKARDEX,COSTOUNITARIO,FECHA_INGRESO,FECHA_DE_SALIDA")] KARDEX kARDEX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kARDEX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kARDEX);
        }

        // GET: KARDEXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KARDEX kARDEX = db.KARDEX.Find(id);
            if (kARDEX == null)
            {
                return HttpNotFound();
            }
            return View(kARDEX);
        }

        // POST: KARDEXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KARDEX kARDEX = db.KARDEX.Find(id);
            db.KARDEX.Remove(kARDEX);
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
