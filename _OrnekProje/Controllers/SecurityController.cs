using _OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _OrnekProje.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        Context db = new Context();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = db.User.Any(u => u.EMail == user.EMail && user.Password == user.Password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.EMail, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Gerçersiz email veya şifre");
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User registerUser)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(registerUser);
                db.SaveChanges();
                return RedirectToAction("Login");

            }
            return View();
        }
    }
}