using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem;

namespace StudentManagementSystem.Controllers
{
    [Authorize]   //important for login signup, if we set the student_reg controller still it will redirct to log in page
    public class student_regformController : Controller
    {
       
        private universityEntities1 db = new universityEntities1();

        // GET: student_regform
        public ActionResult Index()
        {
            return View(db.student_regform.ToList());
        }

        // GET: student_regform/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_regform student_regform = db.student_regform.Find(id);
            if (student_regform == null)
            {
                return HttpNotFound();
            }
            return View(student_regform);
        }

        // GET: student_regform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: student_regform/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nid,Id,Name,Email,Phone,Department,Address")] student_regform student_regform)
        {
            if (ModelState.IsValid)
            {
                db.student_regform.Add(student_regform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_regform);
        }

        // GET: student_regform/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_regform student_regform = db.student_regform.Find(id);
            if (student_regform == null)
            {
                return HttpNotFound();
            }
            return View(student_regform);
        }

        // POST: student_regform/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nid,Id,Name,Email,Phone,Department,Address")] student_regform student_regform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_regform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_regform);
        }

        // GET: student_regform/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_regform student_regform = db.student_regform.Find(id);
            if (student_regform == null)
            {
                return HttpNotFound();
            }
            return View(student_regform);
        }

        // POST: student_regform/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student_regform student_regform = db.student_regform.Find(id);
            db.student_regform.Remove(student_regform);
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
