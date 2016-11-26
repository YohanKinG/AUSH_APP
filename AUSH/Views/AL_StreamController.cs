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
    public class AL_StreamController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: AL_Stream
        public ActionResult Index()
        {
            return View(db.AL_Stream.ToList());
        }

        // GET: AL_Stream/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AL_Stream aL_Stream = db.AL_Stream.Find(id);
            if (aL_Stream == null)
            {
                return HttpNotFound();
            }
            return View(aL_Stream);
        }

        // GET: AL_Stream/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AL_Stream/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StreamID,Name,Description")] AL_Stream aL_Stream)
        {
            if (ModelState.IsValid)
            {
                db.AL_Stream.Add(aL_Stream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aL_Stream);
        }

        // GET: AL_Stream/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AL_Stream aL_Stream = db.AL_Stream.Find(id);
            if (aL_Stream == null)
            {
                return HttpNotFound();
            }
            return View(aL_Stream);
        }

        // POST: AL_Stream/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StreamID,Name,Description")] AL_Stream aL_Stream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aL_Stream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aL_Stream);
        }

        // GET: AL_Stream/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AL_Stream aL_Stream = db.AL_Stream.Find(id);
            if (aL_Stream == null)
            {
                return HttpNotFound();
            }
            return View(aL_Stream);
        }

        // POST: AL_Stream/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AL_Stream aL_Stream = db.AL_Stream.Find(id);
            db.AL_Stream.Remove(aL_Stream);
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
