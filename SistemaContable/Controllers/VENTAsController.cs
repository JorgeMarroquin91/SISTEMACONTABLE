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
    public class VENTAsController : Controller
    {
        private DB_A50304_jorgemarro91Entities db = new DB_A50304_jorgemarro91Entities();

        // GET: VENTAs
        public ActionResult Index()
        {
            var vENTA = db.VENTA.Include(v => v.CATALOGO_DE_PRODUCTO).Include(v => v.CLIENTE).Include(v => v.KARDEX);
            return View(vENTA.ToList());
        }

        // GET: VENTAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // GET: VENTAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO");
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "DUI_CLIENTE");
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX");
            return View();
        }

        // POST: VENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CORRELATIVO_DOC,ID_PRODUCTO,ID_CLIENTE,NUMKARDEX,TIPO_DOCU_VENTA,TIPO_PAGO,CONCEPTO_DE_VENTA,SUBTOTAL,DESCUENTO,GRAVADAS,IVA,IVA_PERSIVIDO,IVA_RETENIDO,VENTAS_EXENTAS,TOTAL")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.VENTA.Add(vENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO", vENTA.ID_PRODUCTO);
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "DUI_CLIENTE", vENTA.ID_CLIENTE);
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX", vENTA.NUMKARDEX);
            return View(vENTA);
        }

        // GET: VENTAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO", vENTA.ID_PRODUCTO);
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "DUI_CLIENTE", vENTA.ID_CLIENTE);
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX", vENTA.NUMKARDEX);
            return View(vENTA);
        }

        // POST: VENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CORRELATIVO_DOC,ID_PRODUCTO,ID_CLIENTE,NUMKARDEX,TIPO_DOCU_VENTA,TIPO_PAGO,CONCEPTO_DE_VENTA,SUBTOTAL,DESCUENTO,GRAVADAS,IVA,IVA_PERSIVIDO,IVA_RETENIDO,VENTAS_EXENTAS,TOTAL")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRODUCTO = new SelectList(db.CATALOGO_DE_PRODUCTO, "ID_PRODUCTO", "DESCRIPCION_PRODUCTO", vENTA.ID_PRODUCTO);
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "DUI_CLIENTE", vENTA.ID_CLIENTE);
            ViewBag.NUMKARDEX = new SelectList(db.KARDEX, "NUMKARDEX", "NUMKARDEX", vENTA.NUMKARDEX);
            return View(vENTA);
        }

        // GET: VENTAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: VENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            db.VENTA.Remove(vENTA);
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
