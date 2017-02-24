using EmployeeManagementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Views.Dashboard
{
    public class DepartmentController : Controller
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.ToList().Where(s => s.Active == "Active"));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            department.Active = "Active";
            department.CreateDate = DateTime.Now;
            department.UpdateDate = DateTime.Now;
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null) id = 1;
            Department department = db.Departments.Find((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            department.UpdateDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) id = 1;
            Department department = db.Departments.Find((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            department.Active = "Inactive";
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null) id = 1;
            Department department = db.Departments.Find((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return PartialView(department);
        }
    }
}