using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using midterm_nick.Models;

namespace midterm_nick.Controllers
{
    public class CourseController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.Courses2.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses2 courses2 = db.Courses2.Find(id);
            if (courses2 == null)
            {
                return HttpNotFound();
            }
            return View(courses2);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseCode,CourseName,CourseDescription,CourseCost")] Courses2 courses2)
        {
            if (ModelState.IsValid)
            {
                db.Courses2.Add(courses2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses2);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses2 courses2 = db.Courses2.Find(id);
            if (courses2 == null)
            {
                return HttpNotFound();
            }
            return View(courses2);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseCode,CourseName,CourseDescription,CourseCost")] Courses2 courses2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses2);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses2 courses2 = db.Courses2.Find(id);
            if (courses2 == null)
            {
                return HttpNotFound();
            }
            return View(courses2);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses2 courses2 = db.Courses2.Find(id);
            db.Courses2.Remove(courses2);
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
