using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reporter_MVC.Models;

namespace Reporter_MVC.Controllers
{
    public class DarkhastsController : Controller
    {
        private ReporterDbContext db = new ReporterDbContext();

        // GET: Darkhasts
        public ActionResult Index()
        {
            return View(db.Darkhasts.ToList());
        }

        // GET: Darkhasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darkhast darkhast = db.Darkhasts.Find(id);
            if (darkhast == null)
            {
                return HttpNotFound();
            }
            return View(darkhast);
        }

        // GET: Darkhasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Darkhasts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,regDate,name,family,NID,type,state,returnDate,serialNumber,postSentDate,postReturnDate,deliveryToApplicant,referingOffic,resendDescription,sendingType,cost,officeCost")] Darkhast darkhast)
        {
            if (ModelState.IsValid)
            {
                db.Darkhasts.Add(darkhast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(darkhast);
        }

        // GET: Darkhasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darkhast darkhast = db.Darkhasts.Find(id);
            if (darkhast == null)
            {
                return HttpNotFound();
            }
            return View(darkhast);
        }

        // POST: Darkhasts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,regDate,name,family,NID,type,state,returnDate,serialNumber,postSentDate,postReturnDate,deliveryToApplicant,referingOffic,resendDescription,sendingType,cost,officeCost")] Darkhast darkhast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darkhast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(darkhast);
        }

        // GET: Darkhasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darkhast darkhast = db.Darkhasts.Find(id);
            if (darkhast == null)
            {
                return HttpNotFound();
            }
            return View(darkhast);
        }

        // POST: Darkhasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Darkhast darkhast = db.Darkhasts.Find(id);
            db.Darkhasts.Remove(darkhast);
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
