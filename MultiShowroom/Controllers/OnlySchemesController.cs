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
    public class OnlySchemesController : Controller
    {
        private TatabaseEntities db = new TatabaseEntities();

        // GET: OnlySchemes
        public ActionResult Index()
        {
            return View(db.Schemes.ToList());
        }

        // GET: OnlySchemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheme scheme = db.Schemes.Find(id);
            if (scheme == null)
            {
                return HttpNotFound();
            }
            return View(scheme);
        }

        // GET: OnlySchemes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlySchemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchemeID,SchemeName,Description")] Scheme scheme)
        {
            if (ModelState.IsValid)
            {
                db.Schemes.Add(scheme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheme);
        }

        // GET: OnlySchemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheme scheme = db.Schemes.Find(id);
            if (scheme == null)
            {
                return HttpNotFound();
            }
            return View(scheme);
        }

        // POST: OnlySchemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchemeID,SchemeName,Description")] Scheme scheme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheme);
        }

        // GET: OnlySchemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheme scheme = db.Schemes.Find(id);
            if (scheme == null)
            {
                return HttpNotFound();
            }
            return View(scheme);
        }

        // POST: OnlySchemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scheme scheme = db.Schemes.Find(id);
            db.Schemes.Remove(scheme);
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
