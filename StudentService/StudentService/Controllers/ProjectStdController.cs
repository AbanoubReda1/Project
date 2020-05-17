using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentService.Controllers
{
    public class ProjectStdController : Controller
    {
        // GET: ProjectStd
        private StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
        {
            List<Project> projectlist = db.Projects.ToList();
            ViewBag.projectlist = new SelectList(projectlist, "ProjectName", "ProjectName");
            var projects = db.Projects.ToList();
            return View(projects.ToList());
        }
        [HttpPost]
        public ActionResult Index(string pro)
        {
            List<Project> projectlist = db.Projects.ToList();
            ViewBag.projectlist = new SelectList(projectlist, "ProjectName", "ProjectName");

            var project = db.Projects.Where(a => a.ProjectName == pro).ToList();

            return View(project);
        }
    }
}
