using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context c = new Context();
        public ActionResult Index()
        {
            var values1 = c.Currents.Count().ToString();
            ViewBag.v1 = values1;
            var values2 = c.Products.Count().ToString();
            ViewBag.v2 = values2;
            var values3 = c.Categories.Count().ToString();
            ViewBag.v3 = values3;
            var values4 = (from x in c.Currents select x.CurrentsCity).Distinct().Count().ToString();
            ViewBag.v4 = values4;
            var values = c.ToDoLists.OrderByDescending(x => x.Id).Take(12).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ToDoList p)
        {
            p.Status = true;
            c.ToDoLists.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var values = c.ToDoLists.Find(id);
            c.ToDoLists.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringToDoList(int id)
        {
            var values = c.ToDoLists.Find(id);
            return View("BringToDoList", values);
        }
        [HttpPost]
        public ActionResult UpdateToDoList(ToDoList p)
        {
            var values = c.ToDoLists.Find(p.Id);
            values.Title = p.Title;
            values.Date = p.Date;
            values.Hour = p.Hour;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Admins()
        {
            var admin = c.Admins.Where(x => x.Status == true).ToList();
            return View(admin);
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult DeleteAdmin(int id)
        {
            var value = c.Admins.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Admins");
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public ActionResult AddAdmin()
        {
            ViewBag.Authority = new List<string>() { "SuperAdmin", "Admin" };
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            ViewBag.Authority = new List<string>() { "SuperAdmin", "Admin" };
            c.Admins.Add(admin);
            admin.Status = true;
            c.SaveChanges();
            return RedirectToAction("Admins");
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = c.Admins.Find(id);
            ViewBag.Authority = new List<string>() { "SuperAdmin", "Admin" };
            return View("UpdateAdmin", value);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var values = c.Admins.Find(admin.Id);
            ViewBag.Authority = new List<string>() { "SuperAdmin", "Admin" };
            values.Authority = admin.Authority;
            c.SaveChanges();
            return RedirectToAction("Admins");
        }
        public ActionResult BestSellers()
        {
            var value = c.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateBestSellers(int id)
        {
            var values = c.Products.Find(id);
            return View("UpdateBestSellers", values);
        }
        [HttpPost]
        public ActionResult UpdateBestSellers(Product product)
        {
            var values = c.Products.Find(product.Id);
            values.BestSellers = product.BestSellers;
            c.SaveChanges();
            return RedirectToAction("BestSellers");
        }
        public ActionResult NewArrivals()
        {
            var value = c.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateNewArrivals(int id)
        {
            var values = c.Products.Find(id);
            return View("UpdateNewArrivals", values);
        }
        [HttpPost]
        public ActionResult UpdateNewArrivals(Product product)
        {
            var values = c.Products.Find(product.Id);
            values.NewArrivals = product.NewArrivals;
            c.SaveChanges();
            return RedirectToAction("NewArrivals");
        }
        public ActionResult Slider()
        {
            var value = c.HomeImages.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlider(HomeImage homeImage)
        {
            if (homeImage.SliderImage != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image4/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    homeImage.SliderImage = "/Image4/" + filesname + extension;
                }
            }
         
            c.HomeImages.Add(homeImage);
            c.SaveChanges();
            return RedirectToAction("Slider");
        }
        public ActionResult DeleteSlider(int id)
        {
            var value = c.HomeImages.Find(id);
            c.HomeImages.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Slider");
        }
        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var values = c.HomeImages.Find(id);
            return View("UpdateSlider",values);
        }
        [HttpPost]
        public ActionResult UpdateSlider(HomeImage homeImage)
        {
            var value = c.HomeImages.Find(homeImage.Id);
            value.Slider = homeImage.Slider;

            if (homeImage.SliderImage != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image4/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    homeImage.SliderImage = "/Image4/" + filesname + extension;
                    value.SliderImage = homeImage.SliderImage;
                }
            }
            c.SaveChanges();
            return RedirectToAction("Slider");
        }
        public ActionResult Categories()
        {
            var value = c.Categories.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateCategories(int id)
        {
            var values = c.Categories.Find(id);
            return View("UpdateCategories",values);
        }
        [HttpPost]
        public ActionResult UpdateCategories(Category category)
        {
            var values = c.Categories.Find(category.Id);
            values.OnHome = category.OnHome;

            if (category.Image != null)
            {
                if (Request.Files.Count > 0)
                {
                    string filesname = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string road = "~/Image5/" + filesname + extension;
                    Request.Files[0].SaveAs(Server.MapPath(road));
                    category.Image = "/Image5/" + filesname + extension;
                    values.Image = category.Image;
                }
            }
            c.SaveChanges();
            return RedirectToAction("Categories");
        }
    }
}