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
    public class PRODUCTO_TERMINADOController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: PRODUCTO_TERMINADO
        public ActionResult Index()
        {
            var pRODUCTO_TERMINADO = db.PRODUCTO_TERMINADO.Include(p => p.COSTO_INDIRECTO).Include(p => p.COTOS_DE_MATERIAL).Include(p => p.KARDEX);
            return View(pRODUCTO_TERMINADO.ToList());
        }

        // GET: PRODUCTO_TERMINADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_TERMINADO pRODUCTO_TERMINADO = db.PRODUCTO_TERMINADO.Find(id);
            if (pRODUCTO_TERMINADO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO_TERMINADO);
        }

        // GET: PRODUCTO_TERMINADO/Create
        public ActionResult Create()
        {
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO");
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL");
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX");
            return View();
        }

        // POST: PRODUCTO_TERMINADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CORRELATIVO_PRODUCTO,NUMKARDEX,ID_COSMATERIAL,ID_COSTO,DESCRIPCION_DEL_PRODUCTO_TERMINADO,EXISTENCIA_PRODUCTO")] PRODUCTO_TERMINADO pRODUCTO_TERMINADO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO_TERMINADO.Add(pRODUCTO_TERMINADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO", pRODUCTO_TERMINADO.ID_COSTO);
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL", pRODUCTO_TERMINADO.ID_COSMATERIAL);
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX", pRODUCTO_TERMINADO.NUMKARDEX);
            return View(pRODUCTO_TERMINADO);
        }

        // GET: PRODUCTO_TERMINADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_TERMINADO pRODUCTO_TERMINADO = db.PRODUCTO_TERMINADO.Find(id);
            if (pRODUCTO_TERMINADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO", pRODUCTO_TERMINADO.ID_COSTO);
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL", pRODUCTO_TERMINADO.ID_COSMATERIAL);
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX", pRODUCTO_TERMINADO.NUMKARDEX);
            return View(pRODUCTO_TERMINADO);
        }

        // POST: PRODUCTO_TERMINADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CORRELATIVO_PRODUCTO,NUMKARDEX,ID_COSMATERIAL,ID_COSTO,DESCRIPCION_DEL_PRODUCTO_TERMINADO,EXISTENCIA_PRODUCTO")] PRODUCTO_TERMINADO pRODUCTO_TERMINADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO_TERMINADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COSTO = new SelectList(db.COSTO_INDIRECTO, "ID_COSTO", "ID_COSTO", pRODUCTO_TERMINADO.ID_COSTO);
            ViewBag.ID_COSMATERIAL = new SelectList(db.COTOS_DE_MATERIAL, "ID_COSMATERIAL", "ID_COSMATERIAL", pRODUCTO_TERMINADO.ID_COSMATERIAL);
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX", pRODUCTO_TERMINADO.NUMKARDEX);
            return View(pRODUCTO_TERMINADO);
        }

        // GET: PRODUCTO_TERMINADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_TERMINADO pRODUCTO_TERMINADO = db.PRODUCTO_TERMINADO.Find(id);
            if (pRODUCTO_TERMINADO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO_TERMINADO);
        }

        // POST: PRODUCTO_TERMINADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO_TERMINADO pRODUCTO_TERMINADO = db.PRODUCTO_TERMINADO.Find(id);
            db.PRODUCTO_TERMINADO.Remove(pRODUCTO_TERMINADO);
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
