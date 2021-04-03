using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;
using PagedList;
using PagedList.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles="SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category q)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            q.OnHome = false;
            c.Categories.Add(q);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var values = c.Categories.Find(id);
            c.Categories.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringCategory(int id)
        {
            var values = c.Categories.Find(id);
            return View("BringCategory", values);
        }
        public ActionResult UpdateCategory(Category q)
        {
            if (!ModelState.IsValid)
            {
                return View("BringCategory");
            }

            var values = c.Categories.Find(q.Id);
            values.CategoryName = q.CategoryName;

            c.SaveChanges();
            return RedirectToAction("Index");
        }   
        public JsonResult BringProduct(int p)
        {
            var productlist = (from x in c.Products
                               join y in c.Categories
                               on x.Category.Id equals y.Id
                               where x.Category.Id == p
                               select new
                               {
                                   Text = x.ProductsName,
                                   Value = x.Id.ToString()
                               });
            return Json(productlist,JsonRequestBehavior.AllowGet);
        }
    }
}