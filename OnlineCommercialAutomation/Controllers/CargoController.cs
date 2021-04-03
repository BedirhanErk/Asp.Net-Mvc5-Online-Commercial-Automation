using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var values = from x in c.Cargos select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.TrackingCode.Contains(p));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            Random rnd = new Random();
            string[] characters = { "A", "B", "C", "D" };
            int c1, c2, c3;
            c1 = rnd.Next(0, 4);
            c2 = rnd.Next(0, 4);
            c3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + characters[c1] + s2 + characters[c2] + s3 + characters[c3];
            ViewBag.tcode = code;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Cargo p)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            c.Cargos.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var values = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EnterDescription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnterDescription(CargoTracking cargoTracking, string id)
        {
            cargoTracking.TrackingCode = id;
            c.CargoTrackings.Add(cargoTracking);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}