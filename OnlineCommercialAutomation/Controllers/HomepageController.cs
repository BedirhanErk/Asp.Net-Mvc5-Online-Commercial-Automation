using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [AllowAnonymous]
    public class HomepageController : Controller
    {
        // GET: Homepage
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Slider()
        {
            var values = c.HomeImages.Where(x => x.Slider == true).OrderByDescending(x => x.Id).Take(4).ToList();
            return PartialView(values);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public PartialViewResult NewArrivals()
        {
            var na = c.Products.Where(x => x.NewArrivals == true).Take(4).OrderByDescending(x => x.Id).ToList();
            return PartialView(na);
        }
        public PartialViewResult BestSellers()
        {
            var bs = c.Products.Where(x => x.BestSellers == true).Take(4).OrderByDescending(x => x.Id).ToList();
            return PartialView(bs);
        }
        public PartialViewResult Categories()
        {
            var cat = c.Categories.Where(x=>x.OnHome == true).OrderByDescending(x=>x.Id).Take(6).ToList();
            return PartialView(cat);
        }      
    }
}