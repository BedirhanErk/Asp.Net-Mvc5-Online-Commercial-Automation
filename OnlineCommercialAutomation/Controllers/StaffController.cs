using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Staffs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.value2 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Staff s)
        {
            if (s.StaffImage != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    s.StaffImage = "/Image/" + filesname + extension;
                }
            }
            
            c.Staffs.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringStaff(int id)
        {
            List<SelectListItem> value3 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.value4 = value3;
            var values = c.Staffs.Find(id);
            return View("BringStaff",values);
        }
        public ActionResult UpdateStaff(Staff s)
        {
            var values = c.Staffs.Find(s.Id);
            values.StaffName = s.StaffName;
            values.StaffSurname = s.StaffSurname;           
            values.DepartmentId = s.DepartmentId;
            values.Address = s.Address;
            values.Phone = s.Phone;

            if (s.StaffImage != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    s.StaffImage = "/Image/" + filesname + extension;
                    values.StaffImage = s.StaffImage;
                }
            }
                 
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffList()
        {
            var values = c.Staffs.ToList();
            return View(values);
        }
    }
}