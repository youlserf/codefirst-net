using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codefirst_net;
using codefirst_net.Models;

namespace codefirst_net.Controllers
{
    public class DetailsController : Controller
    {
        private InvoiceSystemContext db = new InvoiceSystemContext();

        // GET: Details
        public ActionResult Index()
        {
            var details = db.Details.Include(d => d.Invoice).Include(d => d.Product);
            return View(details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: Details/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetailId,InvoiceId,ProductId,Quantity")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", detail.InvoiceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", detail.ProductId);
            return View(detail);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", detail.InvoiceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", detail.ProductId);
            return View(detail);
        }

        // POST: Details/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetailId,InvoiceId,ProductId,Quantity")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "InvoiceId", detail.InvoiceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", detail.ProductId);
            return View(detail);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
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
