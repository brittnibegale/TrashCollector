using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickUpDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickUpDays
        public ActionResult Index()
        {
            var pickUpDay = db.PickUpDay.Include(p => p.Day);
            return View(pickUpDay.ToList());
        }

        // GET: PickUpDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpDay pickUpDay = db.PickUpDay.Find(id);
            if (pickUpDay == null)
            {
                return HttpNotFound();
            }
            return View(pickUpDay);
        }

        // GET: PickUpDays/Create
        public ActionResult Create()
        {
            ViewBag.DayID = new SelectList(db.Day, "ID", "DayChoice");
            return View();
        }

        // POST: PickUpDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cost,day1,day2,Weeks,DayID")] PickUpDay pickUpDay)
        {
            if (ModelState.IsValid)
            {
                db.PickUpDay.Add(pickUpDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DayID = new SelectList(db.Day, "ID", "DayChoice", pickUpDay.DayID);
            return View(pickUpDay);
        }

        // GET: PickUpDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpDay pickUpDay = db.PickUpDay.Find(id);
            if (pickUpDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayID = new SelectList(db.Day, "ID", "DayChoice", pickUpDay.DayID);
            return View(pickUpDay);
        }

        // POST: PickUpDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,day1,day2,Weeks,DayID")] PickUpDay pickUpDay)
        {
            if (ModelState.IsValid)
            {
                pickUpDay.Cost = Int32.Parse(pickUpDay.Weeks) * 5;
                db.Entry(pickUpDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DayID = new SelectList(db.Day, "ID", "DayChoice", pickUpDay.DayID);
            return View(pickUpDay);
        }

        // GET: PickUpDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUpDay pickUpDay = db.PickUpDay.Find(id);
            if (pickUpDay == null)
            {
                return HttpNotFound();
            }
            return View(pickUpDay);
        }

        // POST: PickUpDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickUpDay pickUpDay = db.PickUpDay.Find(id);
            db.PickUpDay.Remove(pickUpDay);
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
