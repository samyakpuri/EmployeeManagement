using EmployeeManagementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : Controller
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        // GET: Project
        public ActionResult Index()
        {
            return View(db.Projects.ToList().Where(s => s.Active == "Active"));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            project.Active = "Active";
            project.CreateDate = DateTime.Now;
            project.UpdateDate = DateTime.Now;
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) id = 1;
            Project project = db.Projects.Find((int)id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            project.UpdateDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) id = 1;
            Project project = db.Projects.Find((int)id);
            if (project == null)
            {
                return HttpNotFound();
            }
            project.Active = "Inactive";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}