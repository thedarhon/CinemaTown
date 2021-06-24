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
    public class SellTicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SellTickets
        public ActionResult Index()
        {
            return View(db.SellTickets.ToList());
        }

        // GET: SellTickets/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellTickets sellTicket = db.SellTickets.Find(id);
            if (sellTicket == null)
            {
                return HttpNotFound();
            }
            return View(sellTicket);
        }
        public void PopulateSellTicketsDropDownList(object selectTicket = null)
        {
            var TicketQuery = from d in db.Tickets
                              orderby d.Price
                              select d;
            ViewBag.Type = new SelectList(TicketQuery, "Type", null, selectTicket);
        }

        // GET: SellTickets/Create
        public ActionResult Create()
        {
            PopulateSellTicketsDropDownList();
            return View();
        }

        // POST: SellTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Price,Amount")] SellTickets sellTicket)
        {
            if (ModelState.IsValid)
            {
                db.SellTickets.Add(sellTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateSellTicketsDropDownList(sellTicket.Id);
            return View(sellTicket);
        }

        // GET: SellTickets/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellTickets sellTicket = db.SellTickets.Find(id);
            if (sellTicket == null)
            {
                return HttpNotFound();
            }
            return View(sellTicket);
        }

        // POST: SellTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Price,Amount")] SellTickets sellTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellTicket);
        }

        // GET: SellTickets/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellTickets sellTicket = db.SellTickets.Find(id);
            if (sellTicket == null)
            {
                return HttpNotFound();
            }
            return View(sellTicket);
        }

        // POST: SellTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellTickets sellTicket = db.SellTickets.Find(id);
            db.SellTickets.Remove(sellTicket);
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