using EmployeeManagementLib;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class StatusController : Controller
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        // GET: Status
        public ActionResult Index()
        {
            return View(db.Status.ToList().Where(s => s.Active == "Active"));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Status status)
        {
            status.Active = "Active";
            status.CreateDate = DateTime.Now;
            status.UpdateDate = DateTime.Now;
            db.Status.Add(status);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) id = 10;
            Status status = db.Status.Find((int)id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        [HttpPost]
        public ActionResult Edit(Status status)
        {
            status.UpdateDate = DateTime.Now;
            db.Entry(status).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) id = 1;
            Status status = db.Status.Find((int)id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        [HttpPost]
        public ActionResult Delete(Status status)
        {
            
            status.Active = "Inactive";
            status.UpdateDate = DateTime.Now;
            db.Entry(status).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null) id = 1;
            Status status = db.Status.Find((int)id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }
    }
}