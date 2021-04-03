using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineCommercialAutomation.Models.Entities;

namespace OnlineCommercialAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Current current)
        {
            c.Currents.Add(current);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin(Current q)
        {
            var values = c.Currents.FirstOrDefault(x => x.CurrentsMail == q.CurrentsMail && x.Password == q.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CurrentsName,false);
                Session["CurrentsMail"] = values.CurrentsMail.ToString();
                Session.Timeout = 60;
                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Homepage");
        }
    }
}