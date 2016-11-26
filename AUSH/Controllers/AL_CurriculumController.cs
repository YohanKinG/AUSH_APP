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
    public class AL_CurriculumController : Controller
    {
        private AUSH_DBEntities db = new AUSH_DBEntities();

        // GET: AL_Curriculum
        public ActionResult Index()
        {
            return View(db.AL_Curriculum.ToList());
        }

        // GET: AL_Curriculum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AL_Curriculum aL_Curriculum = db.AL_Curriculum.Find(id);
            if (aL_Curriculum == null)
            {
                return HttpNotFound();
            }
            return View(aL_Curriculum);
        }

        // GET: AL_Curriculum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AL_Curriculum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ALCurID,Name,Description,ZorMean")] AL_Curriculum aL_Curriculum)
        {
            if (ModelState.IsValid)
            {
                db.AL_Curriculum.Add(aL_Curriculum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aL_Curriculum);
        }

        // GET: AL_Curriculum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AL_Curriculum aL_Curriculum = db.AL_Curriculum.Find(id);
            if (aL_Curriculum == null)
            {
                return HttpNotFound();
            }
            return View(aL_Curriculum);
        }

        // POST: AL_Curriculum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ALCurID,Name,Description,ZorMean")] AL_Curriculum aL_Curriculum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aL_Curriculum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aL_Curriculum);
        }

        // GET: AL_Curriculum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AL_Curriculum aL_Curriculum = db.AL_Curriculum.Find(id);
            if (aL_Curriculum == null)
            {
                return HttpNotFound();
            }
            return View(aL_Curriculum);
        }

        // POST: AL_Curriculum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AL_Curriculum aL_Curriculum = db.AL_Curriculum.Find(id);
            db.AL_Curriculum.Remove(aL_Curriculum);
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
