using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentService.Models;

namespace StudentService.Controllers
{
    public class SectionsController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: Sections
        public async Task<ActionResult> Index()
        {
            var sections = db.Sections.Include(s => s.Course).Include(s => s.Instructor).Include(s => s.Task);
            return View(await sections.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await db.Sections.FindAsync(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            ViewBag.FKCCode = new SelectList(db.Courses, "CourseNo", "Title");
            ViewBag.FKInCode = new SelectList(db.Instructors, "InstructorNo", "InstructorName");
            ViewBag.FKTCode = new SelectList(db.Tasks, "TaskNo", "TaskPath");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AutoID,SectionNo,Semester,Year,FKCCode,FKInCode,FKTCode")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(section);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FKCCode = new SelectList(db.Courses, "CourseNo", "Title", section.FKCCode);
            ViewBag.FKInCode = new SelectList(db.Instructors, "InstructorNo", "InstructorName", section.FKInCode);
            ViewBag.FKTCode = new SelectList(db.Tasks, "TaskNo", "TaskPath", section.FKTCode);
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await db.Sections.FindAsync(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKCCode = new SelectList(db.Courses, "CourseNo", "Title", section.FKCCode);
            ViewBag.FKInCode = new SelectList(db.Instructors, "InstructorNo", "InstructorName", section.FKInCode);
            ViewBag.FKTCode = new SelectList(db.Tasks, "TaskNo", "TaskPath", section.FKTCode);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AutoID,SectionNo,Semester,Year,FKCCode,FKInCode,FKTCode")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FKCCode = new SelectList(db.Courses, "CourseNo", "Title", section.FKCCode);
            ViewBag.FKInCode = new SelectList(db.Instructors, "InstructorNo", "InstructorName", section.FKInCode);
            ViewBag.FKTCode = new SelectList(db.Tasks, "TaskNo", "TaskPath", section.FKTCode);
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await db.Sections.FindAsync(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Section section = await db.Sections.FindAsync(id);
            db.Sections.Remove(section);
            await db.SaveChangesAsync();
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
