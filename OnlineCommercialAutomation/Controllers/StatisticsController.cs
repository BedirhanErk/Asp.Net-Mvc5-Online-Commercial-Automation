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
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var values1 = c.Currents.Count().ToString();
            ViewBag.d1 = values1;
            var values2 = c.Products.Count().ToString();
            ViewBag.d2 = values2;
            var values3 = c.Staffs.Count().ToString();
            ViewBag.d3 = values3;
            var values4 = c.Categories.Count().ToString();
            ViewBag.d4 = values4;
            var values5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = values5;
            var values6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = values6;
            var values7 = c.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = values7;
            var values8 = (from x in c.Products orderby x.SalesPrice descending select x.ProductsName).FirstOrDefault();
            ViewBag.d8 = values8;
            var values9 = (from x in c.Products orderby x.SalesPrice ascending select x.ProductsName).FirstOrDefault();
            ViewBag.d9 = values9;
            var values10 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = values10;
            var values11 = c.Products.Count(x => x.ProductsName == "Fridge").ToString();
            ViewBag.d11 = values11;
            var values12 = c.Products.Count(x => x.ProductsName == "Laptop").ToString();
            ViewBag.d12 = values12;
            var values13 = c.Products.Where(u=>u.Id== c.SalesMovements.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(k=>k.ProductsName).FirstOrDefault();
            ViewBag.d13 = values13;
            var values14 = c.SalesMovements.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = values14;
            DateTime bugun = DateTime.Today;
            var values15 = c.SalesMovements.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = values15;
            var values16 = c.SalesMovements.Where(x => x.Date == bugun).Sum(y => (decimal?) y.TotalAmount).ToString();
            ViewBag.d16 = values16;
            return View();
        }
        public ActionResult SimpleTables()
        {
            var values = from x in c.Currents
                         group x by x.CurrentsCity into g
                         select new ClassGroup
                         {
                             City = g.Key,
                             Total = g.Count()
                         };
            return View(values.ToList());
        }
        public PartialViewResult Partial1()
        {
            var values2 = from x in c.Staffs
                          group x by x.Department.DepartmentName into g
                          select new ClassGroup2
                          {
                              Department = g.Key,
                              Total = g.Count()
                          };
            return PartialView(values2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var values = c.Currents.ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial3()
        {
            var values = c.Products.ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial4()
        {
            var values3 = from x in c.Products
                          group x by x.Brand into g
                          select new ClassGroup3
                          {
                              Brand = g.Key,
                              Total = g.Count()
                          };
            return PartialView(values3.ToList());
        }
        public PartialViewResult Partial5()
        {
            var values4 = from x in c.Products
                          group x by x.ProductsName into g
                          select new ClassGroup4
                          {
                              ProductsName = g.Key,
                              Total = g.Count()
                          };
            return PartialView(values4.ToList());
        }
    }
}