using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentService.Models;

namespace StudentService.Controllers
{
    public class TasksController : Controller
    {
        private readonly StudentServiceEntities db = new StudentServiceEntities();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.Section).Include(t => t.Type1);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "CourseTitle ");
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode");
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeName");
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber ");
            ViewBag.Semester = new SelectList(db.Sections, "SectionNumber", "Semester ");
            ViewBag.Year = new SelectList(db.Sections, "SectionNumber", "Year ");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskNumber,DepartmentCode,CourseCode,SectionNumber,Semester,Year,TaskHeader,TaskDetails,Type")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Year = new SelectList(db.Sections, "SectionNumber", "Year ", task.Section);
            ViewBag.Semester = new SelectList(db.Sections, "SectionNumber", "Semester ", task.Semester);
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber ", task.Section);
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "CourseTitle ", task.CourseCode);
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode", task.DepartmentCode);
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeName", task.Type);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentCode = new SelectList(db.Sections, "DepartmentCode", "InstructorID", task.DepartmentCode);
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeName", task.Type);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskNumber,DepartmentCode,CourseCode,SectionNumber,Semester,Year,TaskHeader,TaskDetails,Type")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentCode = new SelectList(db.Sections, "DepartmentCode", "InstructorID", task.DepartmentCode);
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeName", task.Type);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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
