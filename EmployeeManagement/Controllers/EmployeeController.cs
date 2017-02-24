using EmployeeManagementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            db.Employees.Add(employee);
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) id = 1;
            Employee employee = db.Employees.Find((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) id = 1;
            Employee employee = db.Employees.Find((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            employee.Active = "Inactive";
            return View();
        }
    }
}