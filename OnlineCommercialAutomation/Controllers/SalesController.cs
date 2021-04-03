using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles="SuperAdmin,Admin")]
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesMovements.ToList();
            return View(values);
        }
        public ActionResult BringSales(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList() select new SelectListItem { Text = x.ProductsName, Value = x.Id.ToString() }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList() select new SelectListItem { Text = x.CurrentsName + " " + x.CurrentsSurname, Value = x.Id.ToString() }).ToList();
            List<SelectListItem> value3 = (from x in c.Staffs.ToList() select new SelectListItem { Text = x.StaffName + " " + x.StaffSurname, Value = x.Id.ToString() }).ToList();
            ViewBag.values1 = value1;
            ViewBag.values2 = value2;
            ViewBag.values3 = value3;
            var values = c.SalesMovements.Find(id);
            return View("BringSales",values);
        }
        public ActionResult UpdateSales(SalesMovement q)
        {
            var values = c.SalesMovements.Find(q.Id);
            values.ProductId = q.ProductId;
            values.CurrentId = q.CurrentId;
            values.StaffId = q.StaffId;
            values.Piece = q.Piece;
            values.Price = q.Price;
            values.TotalAmount = q.TotalAmount;
            values.Date = q.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult SalesDetails(int id)
        {
            var values = c.SalesMovements.Where(x => x.Id == id).ToList();
            return View(values);
        }
        public ActionResult SaleList()
        {
            var values = c.SalesMovements.ToList();
            return View(values);
        }
    }
}