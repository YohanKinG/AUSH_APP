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
    public class DegreeProgramsController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: DegreePrograms
        public ActionResult Index()
        {
            return View(db.DegreePrograms.ToList());
        }

        // GET: DegreePrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeProgram degreeProgram = db.DegreePrograms.Find(id);
            if (degreeProgram == null)
            {
                return HttpNotFound();
            }
            return View(degreeProgram);
        }

        // GET: DegreePrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DegreePrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeID,Name,Description")] DegreeProgram degreeProgram)
        {
            if (ModelState.IsValid)
            {
                db.DegreePrograms.Add(degreeProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degreeProgram);
        }

        // GET: DegreePrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeProgram degreeProgram = db.DegreePrograms.Find(id);
            if (degreeProgram == null)
            {
                return HttpNotFound();
            }
            return View(degreeProgram);
        }

        // POST: DegreePrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeID,Name,Description")] DegreeProgram degreeProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degreeProgram);
        }

        // GET: DegreePrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeProgram degreeProgram = db.DegreePrograms.Find(id);
            if (degreeProgram == null)
            {
                return HttpNotFound();
            }
            return View(degreeProgram);
        }

        // POST: DegreePrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DegreeProgram degreeProgram = db.DegreePrograms.Find(id);
            db.DegreePrograms.Remove(degreeProgram);
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
