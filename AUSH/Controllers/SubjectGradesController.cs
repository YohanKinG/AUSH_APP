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
    public class SubjectGradesController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: SubjectGrades
        public ActionResult Index()
        {
            return View(db.SubjectGrades.ToList());
        }

        // GET: SubjectGrades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            if (subjectGrade == null)
            {
                return HttpNotFound();
            }
            return View(subjectGrade);
        }

        // GET: SubjectGrades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradeID,Grade,Description")] SubjectGrade subjectGrade)
        {
            if (ModelState.IsValid)
            {
                db.SubjectGrades.Add(subjectGrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subjectGrade);
        }

        // GET: SubjectGrades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            if (subjectGrade == null)
            {
                return HttpNotFound();
            }
            return View(subjectGrade);
        }

        // POST: SubjectGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradeID,Grade,Description")] SubjectGrade subjectGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subjectGrade);
        }

        // GET: SubjectGrades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            if (subjectGrade == null)
            {
                return HttpNotFound();
            }
            return View(subjectGrade);
        }

        // POST: SubjectGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectGrade subjectGrade = db.SubjectGrades.Find(id);
            db.SubjectGrades.Remove(subjectGrade);
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
