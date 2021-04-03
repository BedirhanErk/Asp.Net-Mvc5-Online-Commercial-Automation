using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;
namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department q)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            c.Departments.Add(q);
            q.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var values = c.Departments.Find(id);
            values.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringDepartment(int id)
        {
            var values = c.Departments.Find(id);
            return View("BringDepartment", values);
        }
        public ActionResult UpdateDepartment(Department d)
        {
            if (!ModelState.IsValid)
            {
                return View("BringDepartment");
            }
            var values = c.Departments.Find(d.Id);
            values.DepartmentName = d.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var values = c.Staffs.Where(x => x.DepartmentId == id).ToList();
            var values2 = c.Departments.Where(x => x.Id == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.dp = values2;
            return View(values);
        }
        public ActionResult DepartmentStaffSales(int id)
        {
            var values = c.SalesMovements.Where(x => x.StaffId == id).ToList();
            var values2 = c.Staffs.Where(x => x.Id == id).Select(y => y.StaffName +" "+ y.StaffSurname).FirstOrDefault();
            ViewBag.dpersonel = values2;
            return View(values);
        }

    }
}