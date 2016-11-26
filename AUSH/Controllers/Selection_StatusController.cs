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
    public class Selection_StatusController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: Selection_Status
        public ActionResult Index()
        {
            return View(db.Selection_Status.ToList());
        }

        // GET: Selection_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection_Status selection_Status = db.Selection_Status.Find(id);
            if (selection_Status == null)
            {
                return HttpNotFound();
            }
            return View(selection_Status);
        }

        // GET: Selection_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Selection_Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SelectionStatusID,Type,Description")] Selection_Status selection_Status)
        {
            if (ModelState.IsValid)
            {
                db.Selection_Status.Add(selection_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selection_Status);
        }

        // GET: Selection_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection_Status selection_Status = db.Selection_Status.Find(id);
            if (selection_Status == null)
            {
                return HttpNotFound();
            }
            return View(selection_Status);
        }

        // POST: Selection_Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SelectionStatusID,Type,Description")] Selection_Status selection_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selection_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(selection_Status);
        }

        // GET: Selection_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection_Status selection_Status = db.Selection_Status.Find(id);
            if (selection_Status == null)
            {
                return HttpNotFound();
            }
            return View(selection_Status);
        }

        // POST: Selection_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Selection_Status selection_Status = db.Selection_Status.Find(id);
            db.Selection_Status.Remove(selection_Status);
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
