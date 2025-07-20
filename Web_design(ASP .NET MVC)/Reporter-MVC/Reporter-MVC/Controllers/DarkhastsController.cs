using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Create(Darkhast darkhast)
        {
            ValidateNationalCode(darkhast.NID);

            if (ModelState.IsValid)
            {
                try
                {
                    db.Darkhasts.Add(darkhast);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "خطا در ایجاد درخواست: " + ex.Message);
                }
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
        public ActionResult Edit(Darkhast darkhast)
        {
            ValidateNationalCode(darkhast.NID);

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(darkhast).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "خطا در ذخیره تغییرات: " + ex.Message);
                }
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
            try
            {
                Darkhast darkhast = db.Darkhasts.Find(id);
                if (darkhast == null)
                {
                    return HttpNotFound();
                }

                db.Darkhasts.Remove(darkhast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "خطا در حذف درخواست: " + ex.Message);
                return View("Delete", db.Darkhasts.Find(id));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // تابع اعتبارسنجی کد ملی
        private void ValidateNationalCode(string nationalCode)
        {
            if (!string.IsNullOrEmpty(nationalCode))
            {
                // بررسی طول کد ملی
                if (nationalCode.Length != 10)
                {
                    ModelState.AddModelError("NID", "کد ملی باید 10 رقم باشد");
                    return;
                }

                // بررسی عددی بودن
                if (!nationalCode.All(char.IsDigit))
                {
                    ModelState.AddModelError("NID", "کد ملی باید فقط شامل عدد باشد");
                    return;
                }

                // الگوریتم اعتبارسنجی کد ملی ایران
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += (10 - i) * int.Parse(nationalCode[i].ToString());
                }
                int remainder = sum % 11;
                int controlDigit = int.Parse(nationalCode[9].ToString());

                bool isValid = (remainder < 2 && controlDigit == remainder) ||
                              (remainder >= 2 && controlDigit == (11 - remainder));

                if (!isValid)
                {
                    ModelState.AddModelError("NID", "کد ملی معتبر نیست");
                }
            }
        }
    }
}