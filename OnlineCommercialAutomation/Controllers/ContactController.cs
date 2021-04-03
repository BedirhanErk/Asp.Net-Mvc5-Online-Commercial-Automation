using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context c = new Context();
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Contact p)
        {
            c.Contacts.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles="SuperAdmin,Admin")]
        public ActionResult Contact()
        {
            var values = c.Contacts.ToList();
            return View(values);
        }
        [Authorize(Roles ="SuperAdmin,Admin")]
        public ActionResult ContactDelete(int id)
        {
            var values = c.Contacts.Find(id);
            c.Contacts.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Contact");
        }
    }
}