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
    public class PERIODOesController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: PERIODOes
        public ActionResult Index()
        {
            return View(db.PERIODO.ToList());
        }

        // GET: PERIODOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODO pERIODO = db.PERIODO.Find(id);
            if (pERIODO == null)
            {
                return HttpNotFound();
            }
            return View(pERIODO);
        }

        // GET: PERIODOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERIODOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NUMPERIODO,DEBE_,FIN_PERIODO")] PERIODO pERIODO)
        {
            if (ModelState.IsValid)
            {
                db.PERIODO.Add(pERIODO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERIODO);
        }

        // GET: PERIODOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODO pERIODO = db.PERIODO.Find(id);
            if (pERIODO == null)
            {
                return HttpNotFound();
            }
            return View(pERIODO);
        }

        // POST: PERIODOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NUMPERIODO,DEBE_,FIN_PERIODO")] PERIODO pERIODO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERIODO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERIODO);
        }

        // GET: PERIODOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODO pERIODO = db.PERIODO.Find(id);
            if (pERIODO == null)
            {
                return HttpNotFound();
            }
            return View(pERIODO);
        }

        // POST: PERIODOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PERIODO pERIODO = db.PERIODO.Find(id);
            db.PERIODO.Remove(pERIODO);
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
