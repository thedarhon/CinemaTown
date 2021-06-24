using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaTown.Models;

namespace CinemaTown.Controllers
{
    public class SellProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SellProducts
        public ActionResult Index()
        {
            return View(db.SellProducts.ToList());
        }

        // GET: SellProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellProducts sellProduct = db.SellProducts.Find(id);
            if (sellProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellProduct);
        }
        public void PopulateSellProductsDropDownList(object selectProduct = null)
        {
            var ProductQuery = from d in db.Products
                               orderby d.Price
                               select d;
            ViewBag.Type = new SelectList(ProductQuery, "Type", null, selectProduct);

            ProductQuery = from d in db.Products
                           orderby d.Price
                           select d;

            ViewBag.ProductName = new SelectList(ProductQuery, "ProductName", "ProductName", selectProduct);
        }


        // GET: SellProducts/Create
        public ActionResult Create()
        {
            PopulateSellProductsDropDownList();
            return View();
        }

        // POST: SellProducts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Price,ProductName,Amount")] SellProducts sellProduct)
        {
            if (ModelState.IsValid)
            {

                db.SellProducts.Add(sellProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateSellProductsDropDownList(sellProduct.Id);
            return View(sellProduct);
        }

        // GET: SellProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellProducts sellProduct = db.SellProducts.Find(id);
            if (sellProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellProduct);
        }

        // POST: SellProducts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Price,ProductName,Amount")] SellProducts sellProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellProduct);
        }

        // GET: SellProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellProducts sellProduct = db.SellProducts.Find(id);
            if (sellProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellProduct);
        }

        // POST: SellProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellProducts sellProduct = db.SellProducts.Find(id);
            db.SellProducts.Remove(sellProduct);
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

