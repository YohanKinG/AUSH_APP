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
    public class Foundation_ResultController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: Foundation_Result
        public ActionResult Index()
        {
            return View(db.Foundation_Result.ToList());
        }

        // GET: Foundation_Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foundation_Result foundation_Result = db.Foundation_Result.Find(id);
            if (foundation_Result == null)
            {
                return HttpNotFound();
            }
            return View(foundation_Result);
        }

        // GET: Foundation_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foundation_Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoundationResultID,Type,Description")] Foundation_Result foundation_Result)
        {
            if (ModelState.IsValid)
            {
                db.Foundation_Result.Add(foundation_Result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foundation_Result);
        }

        // GET: Foundation_Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foundation_Result foundation_Result = db.Foundation_Result.Find(id);
            if (foundation_Result == null)
            {
                return HttpNotFound();
            }
            return View(foundation_Result);
        }

        // POST: Foundation_Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoundationResultID,Type,Description")] Foundation_Result foundation_Result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foundation_Result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foundation_Result);
        }

        // GET: Foundation_Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foundation_Result foundation_Result = db.Foundation_Result.Find(id);
            if (foundation_Result == null)
            {
                return HttpNotFound();
            }
            return View(foundation_Result);
        }

        // POST: Foundation_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foundation_Result foundation_Result = db.Foundation_Result.Find(id);
            db.Foundation_Result.Remove(foundation_Result);
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
