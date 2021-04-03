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
    [AllowAnonymous]
    public class ListController : Controller
    {
        // GET: List
        Context c = new Context();
        public ActionResult Index(int page=1)
        {
            var values = c.Products.ToList().ToPagedList(page,9);
            return View(values);
        }
        public ActionResult Details(int id)
        {
            var values = c.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(values);
        }
        public PartialViewResult Categories()
        {
            var cat = c.Categories.ToList();
            return PartialView(cat);
        }
        public ActionResult Product(int id,int? page)
        {
            var prdct = c.Products.Where(x => x.CategoryId == id).ToList().ToPagedList(page ?? 1,9);
            var categoryname = c.Categories.Where(x => x.Id == id).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.categoryname = categoryname;
            return View(prdct);
        }
        public ActionResult SearchProduct(string word)
        {
            var value = HttpContext.Request.QueryString["word"].ToString();
            var sw = HttpContext.Request.QueryString["word"].ToString();
            ViewBag.sw = sw;
            var value2 = c.Products.Where(x => x.ProductsName.ToLower().Contains(value.ToLower()) == value.ToLower().Contains(value.ToLower())).ToList();
            var nopf = value2.Count();
            ViewBag.nopf = nopf;
            return View(value2);
        }
    }
}