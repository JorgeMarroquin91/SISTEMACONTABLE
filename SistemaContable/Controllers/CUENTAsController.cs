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
    public class CUENTAsController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: CUENTAs
        public ActionResult Index()
        {
            return View(db.CUENTA.ToList());
        }

        // GET: CUENTAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // GET: CUENTAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CUENTA,NOM_CUENTA")] CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.CUENTA.Add(cUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUENTA);
        }

        // GET: CUENTAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // POST: CUENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CUENTA,NOM_CUENTA")] CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUENTA);
        }

        // GET: CUENTAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // POST: CUENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CUENTA cUENTA = db.CUENTA.Find(id);
            db.CUENTA.Remove(cUENTA);
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
