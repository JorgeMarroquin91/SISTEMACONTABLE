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
    public class HOJA_DE_TRABAJOController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: HOJA_DE_TRABAJO
        public ActionResult Index()
        {
            return View(db.HOJA_DE_TRABAJO.ToList());
        }

        // GET: HOJA_DE_TRABAJO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOJA_DE_TRABAJO hOJA_DE_TRABAJO = db.HOJA_DE_TRABAJO.Find(id);
            if (hOJA_DE_TRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(hOJA_DE_TRABAJO);
        }

        // GET: HOJA_DE_TRABAJO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOJA_DE_TRABAJO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HOJA,SALARIO_HOR_NOMAL,SALRIOHORASEXTRAS,HORASTRABAJADAS,HORASEXTRAS")] HOJA_DE_TRABAJO hOJA_DE_TRABAJO)
        {
            if (ModelState.IsValid)
            {
                db.HOJA_DE_TRABAJO.Add(hOJA_DE_TRABAJO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOJA_DE_TRABAJO);
        }

        // GET: HOJA_DE_TRABAJO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOJA_DE_TRABAJO hOJA_DE_TRABAJO = db.HOJA_DE_TRABAJO.Find(id);
            if (hOJA_DE_TRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(hOJA_DE_TRABAJO);
        }

        // POST: HOJA_DE_TRABAJO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HOJA,SALARIO_HOR_NOMAL,SALRIOHORASEXTRAS,HORASTRABAJADAS,HORASEXTRAS")] HOJA_DE_TRABAJO hOJA_DE_TRABAJO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOJA_DE_TRABAJO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOJA_DE_TRABAJO);
        }

        // GET: HOJA_DE_TRABAJO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOJA_DE_TRABAJO hOJA_DE_TRABAJO = db.HOJA_DE_TRABAJO.Find(id);
            if (hOJA_DE_TRABAJO == null)
            {
                return HttpNotFound();
            }
            return View(hOJA_DE_TRABAJO);
        }

        // POST: HOJA_DE_TRABAJO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOJA_DE_TRABAJO hOJA_DE_TRABAJO = db.HOJA_DE_TRABAJO.Find(id);
            db.HOJA_DE_TRABAJO.Remove(hOJA_DE_TRABAJO);
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
