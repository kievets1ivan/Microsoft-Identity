using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authorizing.App_Start;
using Authorizing.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;


namespace Authorizing.Controllers
{
    public class AccountController : Controller
    {
        // вынести в конструктор
        private IAuthenticationManager _authManager => HttpContext.GetOwinContext().Authentication;
        //private ApplicationUserManager _userManager => new ApplicationUserManager(new UserStore<ApplicationUser>());
        private ApplicationUserManager _userManager => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();


        public ActionResult Index()
        {
            return View("Register");
        }
        // GET: Account
        public ActionResult Register(RegisterModel registerModel)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            

            var user = new ApplicationUser() { UserName = registerModel.UserName, Email = registerModel.UserName };
            IdentityResult result = _userManager.Create(user, registerModel.Password); // check

            if (result.Succeeded)
            {
                ViewBag.StatusMessage = string.Format("User {0} was created successfully!", user.UserName);

                var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                _authManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                _userManager.SendEmailAsync(userIdentity.GetUserId(), "Confirmation", "");
                // send sms 
                return View("RegisterSuccess");
            }
            else
            {
                ViewBag.StatusMessage = result.Errors.FirstOrDefault();
            }

            return View();
        }

        public ActionResult Logout()
        {
            _authManager.SignOut();
            return View("Logout");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var user = _userManager.FindByName(loginModel.Login);

            if (user != null)
            {
                var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                _authManager.SignIn(new AuthenticationProperties() { }, userIdentity);

            }

            return View(loginModel);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
