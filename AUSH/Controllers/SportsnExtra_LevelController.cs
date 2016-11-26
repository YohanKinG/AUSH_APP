using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AUSH;

namespace AUSH.Views
{
    public class SportsnExtra_LevelController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: SportsnExtra_Level
        public ActionResult Index()
        {
            return View(db.SportsnExtra_Level.ToList());
        }

        // GET: SportsnExtra_Level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsnExtra_Level sportsnExtra_Level = db.SportsnExtra_Level.Find(id);
            if (sportsnExtra_Level == null)
            {
                return HttpNotFound();
            }
            return View(sportsnExtra_Level);
        }

        // GET: SportsnExtra_Level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportsnExtra_Level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SprtnExtraID,Type,Description")] SportsnExtra_Level sportsnExtra_Level)
        {
            if (ModelState.IsValid)
            {
                db.SportsnExtra_Level.Add(sportsnExtra_Level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sportsnExtra_Level);
        }

        // GET: SportsnExtra_Level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsnExtra_Level sportsnExtra_Level = db.SportsnExtra_Level.Find(id);
            if (sportsnExtra_Level == null)
            {
                return HttpNotFound();
            }
            return View(sportsnExtra_Level);
        }

        // POST: SportsnExtra_Level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SprtnExtraID,Type,Description")] SportsnExtra_Level sportsnExtra_Level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportsnExtra_Level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportsnExtra_Level);
        }

        // GET: SportsnExtra_Level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsnExtra_Level sportsnExtra_Level = db.SportsnExtra_Level.Find(id);
            if (sportsnExtra_Level == null)
            {
                return HttpNotFound();
            }
            return View(sportsnExtra_Level);
        }

        // POST: SportsnExtra_Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SportsnExtra_Level sportsnExtra_Level = db.SportsnExtra_Level.Find(id);
            db.SportsnExtra_Level.Remove(sportsnExtra_Level);
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
