using OnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Messages.Where(x => x.Sender == "admin").ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult MakeAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeAnnouncement(Message message)
        {
            if (!ModelState.IsValid)
            {
                return View("MakeAnnouncement");
            }
            c.Messages.Add(message);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var values = c.Messages.Find(id);
            c.Messages.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = c.Messages.Find(id);
            return View("Update",value);
        }
        [HttpPost]
        public ActionResult Update(Message message)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            var value = c.Messages.Find(message.MessageId);
            value.Title = message.Title;
            value.Content = message.Content;
            value.Date = message.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}