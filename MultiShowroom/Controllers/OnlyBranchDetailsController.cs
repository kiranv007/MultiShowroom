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
    public class OnlyBranchDetailsController : Controller
    {
        private TatabaseEntities db = new TatabaseEntities();

        // GET: OnlyBranchDetails
        public ActionResult Index()
        {
            return View(db.BranchDetails.ToList());
        }

        // GET: OnlyBranchDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            if (branchDetail == null)
            {
                return HttpNotFound();
            }
            return View(branchDetail);
        }

        // GET: OnlyBranchDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlyBranchDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchID,BranchName,City,Address")] BranchDetail branchDetail)
        {
            if (ModelState.IsValid)
            {
                db.BranchDetails.Add(branchDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branchDetail);
        }

        // GET: OnlyBranchDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            if (branchDetail == null)
            {
                return HttpNotFound();
            }
            return View(branchDetail);
        }

        // POST: OnlyBranchDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchID,BranchName,City,Address")] BranchDetail branchDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchDetail);
        }

        // GET: OnlyBranchDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            if (branchDetail == null)
            {
                return HttpNotFound();
            }
            return View(branchDetail);
        }

        // POST: OnlyBranchDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            db.BranchDetails.Remove(branchDetail);
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
