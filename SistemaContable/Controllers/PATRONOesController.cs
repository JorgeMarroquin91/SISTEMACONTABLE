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
    public class PATRONOesController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: PATRONOes
        public ActionResult Index()
        {
            var pATRONO = db.PATRONO.Include(p => p.LINEA_DE_PLANILLA);
            return View(pATRONO.ToList());
        }

        // GET: PATRONOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATRONO pATRONO = db.PATRONO.Find(id);
            if (pATRONO == null)
            {
                return HttpNotFound();
            }
            return View(pATRONO);
        }

        // GET: PATRONOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA");
            return View();
        }

        // POST: PATRONOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPATRONO,ID_LINEA,ISSS,AFP")] PATRONO pATRONO)
        {
            if (ModelState.IsValid)
            {
                db.PATRONO.Add(pATRONO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", pATRONO.ID_LINEA);
            return View(pATRONO);
        }

        // GET: PATRONOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATRONO pATRONO = db.PATRONO.Find(id);
            if (pATRONO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", pATRONO.ID_LINEA);
            return View(pATRONO);
        }

        // POST: PATRONOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPATRONO,ID_LINEA,ISSS,AFP")] PATRONO pATRONO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATRONO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LINEA = new SelectList(db.LINEA_DE_PLANILLA, "ID_LINEA", "ID_LINEA", pATRONO.ID_LINEA);
            return View(pATRONO);
        }

        // GET: PATRONOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATRONO pATRONO = db.PATRONO.Find(id);
            if (pATRONO == null)
            {
                return HttpNotFound();
            }
            return View(pATRONO);
        }

        // POST: PATRONOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PATRONO pATRONO = db.PATRONO.Find(id);
            db.PATRONO.Remove(pATRONO);
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
