using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles="SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Products.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.value2 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product p)
        {
            if (p.ProductImage != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image2/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    p.ProductImage = "/Image2/" + filesname + extension;
                }
            }
           
            p.Status = true;
            p.NewArrivals = false;
            p.BestSellers = false;
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var values = c.Products.Find(id);
            values.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringProduct(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.value2 = value1;
            var values = c.Products.Find(id);
            return View("BringProduct", values);
        }
        public ActionResult UpdateProduct(Product q)
        {
            var values = c.Products.Find(q.Id);
            values.ProductsName = q.ProductsName;
            values.Brand = q.Brand;
            values.Stock = q.Stock;
            values.BuyingPrice = q.BuyingPrice;
            values.SalesPrice = q.SalesPrice;
            values.CategoryId = q.CategoryId;
           
            values.Status = true;
            values.Explanation = q.Explanation;
            values.Installment = q.Installment;

            if (q.ProductImage != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image2/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    q.ProductImage = "/Image2/" + filesname + extension;
                    values.ProductImage = q.ProductImage;
                }
            }         
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Sell(int id)
        {
            List<SelectListItem> value1 = (from x in c.Staffs.ToList() select new SelectListItem { Text = x.StaffName + " " + x.StaffSurname, Value = x.Id.ToString() }).ToList();
            ViewBag.valuee1 = value1;

            List<SelectListItem> current = (from x in c.Currents.ToList() select new SelectListItem { Text = x.CurrentsName + " " + x.CurrentsSurname, Value = x.Id.ToString() }).ToList();
            ViewBag.current = current;

            var value2 = c.Products.Find(id);
            ViewBag.valuee2 = value2.Id;
            ViewBag.valuee3 = value2.SalesPrice;
            return View();
        }
        [HttpPost]
        public ActionResult Sell(SalesMovement p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
        public ActionResult Gallery()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}