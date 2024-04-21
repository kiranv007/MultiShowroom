using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultiShowroom.Models;

namespace MultiShowroom.Controllers
{
    public class BookingsController : Controller
    {
        private TatabaseEntities db = new TatabaseEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.CarDetail).Include(b => b.CustomerDetail);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarID"); //CarName changed to carID
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "CustomerID");// FirstName to CustomerID
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,CarID,CustomerID,CarName,SchemeName,BookingDate,BookingAmount,UPI_ID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return Redirect("Index");// changed from RedirectTOAction to redirect
            }

            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarID", booking.CarID); // in middle CarName to carID
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "CustomerID", booking.CustomerID);// in middle FirstName to CustomerID
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarName", booking.CarID);
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "FirstName", booking.CustomerID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,CarID,CustomerID,CarName,SchemeName,BookingDate,BookingAmount,UPI_ID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarName", booking.CarID);
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "FirstName", booking.CustomerID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
