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
    public class GlobalDetailsController : Controller
    {
        private ReporterDbContext db = new ReporterDbContext();

        // GET: GlobalDetails
        public ActionResult Index()
        {
            return View(db.GlobalDetails.ToList());
        }

        // GET: GlobalDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalDetail globalDetail = db.GlobalDetails.Find(id);
            if (globalDetail == null)
            {
                return HttpNotFound();
            }
            return View(globalDetail);
        }

        // GET: GlobalDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlobalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,groupCode,groupId,value")] GlobalDetail globalDetail)
        {
            if (ModelState.IsValid)
            {
                db.GlobalDetails.Add(globalDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(globalDetail);
        }

        // GET: GlobalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalDetail globalDetail = db.GlobalDetails.Find(id);
            if (globalDetail == null)
            {
                return HttpNotFound();
            }
            return View(globalDetail);
        }

        // POST: GlobalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,groupCode,groupId,value")] GlobalDetail globalDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(globalDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(globalDetail);
        }

        // GET: GlobalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalDetail globalDetail = db.GlobalDetails.Find(id);
            if (globalDetail == null)
            {
                return HttpNotFound();
            }
            return View(globalDetail);
        }

        // POST: GlobalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlobalDetail globalDetail = db.GlobalDetails.Find(id);
            db.GlobalDetails.Remove(globalDetail);
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
