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
    public class OL_CurriculumController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: OL_Curriculum
        public ActionResult Index()
        {
            return View(db.OL_Curriculum.ToList());
        }

        // GET: OL_Curriculum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OL_Curriculum oL_Curriculum = db.OL_Curriculum.Find(id);
            if (oL_Curriculum == null)
            {
                return HttpNotFound();
            }
            return View(oL_Curriculum);
        }

        // GET: OL_Curriculum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OL_Curriculum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OLCurID,Name,Description")] OL_Curriculum oL_Curriculum)
        {
            if (ModelState.IsValid)
            {
                db.OL_Curriculum.Add(oL_Curriculum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oL_Curriculum);
        }

        // GET: OL_Curriculum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OL_Curriculum oL_Curriculum = db.OL_Curriculum.Find(id);
            if (oL_Curriculum == null)
            {
                return HttpNotFound();
            }
            return View(oL_Curriculum);
        }

        // POST: OL_Curriculum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OLCurID,Name,Description")] OL_Curriculum oL_Curriculum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oL_Curriculum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oL_Curriculum);
        }

        // GET: OL_Curriculum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OL_Curriculum oL_Curriculum = db.OL_Curriculum.Find(id);
            if (oL_Curriculum == null)
            {
                return HttpNotFound();
            }
            return View(oL_Curriculum);
        }

        // POST: OL_Curriculum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OL_Curriculum oL_Curriculum = db.OL_Curriculum.Find(id);
            db.OL_Curriculum.Remove(oL_Curriculum);
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
