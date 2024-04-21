﻿using System;
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
    public class OnlyCarDetailsController : Controller
    {
        private TatabaseEntities db = new TatabaseEntities();

        // GET: OnlyCarDetails
        public ActionResult Index()
        {
            var carDetails = db.CarDetails.Include(c => c.BranchDetail);
            return View(carDetails.ToList());
        }

        // GET: OnlyCarDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarDetail carDetail = db.CarDetails.Find(id);
            if (carDetail == null)
            {
                return HttpNotFound();
            }
            return View(carDetail);
        }

        // GET: OnlyCarDetails/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.BranchDetails, "BranchID", "BranchName");
            return View();
        }

        // POST: OnlyCarDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,CarName,CarPrice,BranchID")] CarDetail carDetail)
        {
            if (ModelState.IsValid)
            {
                db.CarDetails.Add(carDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.BranchDetails, "BranchID", "BranchName", carDetail.BranchID);
            return View(carDetail);
        }

        // GET: OnlyCarDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarDetail carDetail = db.CarDetails.Find(id);
            if (carDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.BranchDetails, "BranchID", "BranchName", carDetail.BranchID);
            return View(carDetail);
        }

        // POST: OnlyCarDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,CarName,CarPrice,BranchID")] CarDetail carDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.BranchDetails, "BranchID", "BranchName", carDetail.BranchID);
            return View(carDetail);
        }

        // GET: OnlyCarDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarDetail carDetail = db.CarDetails.Find(id);
            if (carDetail == null)
            {
                return HttpNotFound();
            }
            return View(carDetail);
        }

        // POST: OnlyCarDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarDetail carDetail = db.CarDetails.Find(id);
            db.CarDetails.Remove(carDetail);
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
