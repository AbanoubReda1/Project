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
    public class StartsController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: Starts
        public async Task<ActionResult> Index()
        {
            return View(await db.Starts.ToListAsync());
        }

        // GET: Starts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Start start = await db.Starts.FindAsync(id);
            if (start == null)
            {
                return HttpNotFound();
            }
            return View(start);
        }

        // GET: Starts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Starts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseNo,Title,CrediteNo,Syllabus,FKDCode,InstructorNo,InstructorName,SectionNo,Semester,Year,TaskNo,TaskPath,FKTypeCode")] Start start)
        {
            if (ModelState.IsValid)
            {
                db.Starts.Add(start);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(start);
        }

        // GET: Starts/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Start start = await db.Starts.FindAsync(id);
            if (start == null)
            {
                return HttpNotFound();
            }
            return View(start);
        }

        // POST: Starts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseNo,Title,CrediteNo,Syllabus,FKDCode,InstructorNo,InstructorName,SectionNo,Semester,Year,TaskNo,TaskPath,FKTypeCode")] Start start)
        {
            if (ModelState.IsValid)
            {
                db.Entry(start).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(start);
        }

        // GET: Starts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Start start = await db.Starts.FindAsync(id);
            if (start == null)
            {
                return HttpNotFound();
            }
            return View(start);
        }

        // POST: Starts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Start start = await db.Starts.FindAsync(id);
            db.Starts.Remove(start);
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
