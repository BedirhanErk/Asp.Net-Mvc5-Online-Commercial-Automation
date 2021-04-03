using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Currents.ToList();
            return View(values);
        }    
        public ActionResult Delete(int id)
        {
            var values = c.Currents.Find(id);
            c.Currents.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var values = c.SalesMovements.Where(x => x.CurrentId == id).ToList();
            var history = c.Currents.Where(x => x.Id == id).Select(y => y.CurrentsName + " " + y.CurrentsSurname).FirstOrDefault();
            ViewBag.values2 = history;
            return View(values);
        }
    }
}