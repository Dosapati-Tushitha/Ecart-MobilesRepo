using MVC_01.DBModel;
using MVC_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_01.Controllers
{
    public class AccountController : Controller
    {

        akshopEntities objUserDBEntities = new akshopEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                Users1 objUSer = new DBModel.Users1();
                objUSer.CreatedOn = DateTime.Now;
                objUSer.FirstName = objUserModel.FirstName;
                objUSer.LastName = objUserModel.LastName;
                objUSer.Email = objUserModel.Email;
                objUSer.Password = objUserModel.Password;
                objUserDBEntities.Users1.Add(objUSer);
                objUserDBEntities.SaveChanges();
                objUserModel = new UserModel();
                objUserModel.SuccessMessage = "User Registered successfully";
                return View(objUserModel);
            }
            else
            {
                return View();
            }
        }

        
        public ActionResult Register()
        {
              UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }

        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                var obj = objUserDBEntities.Users1.Where(s => s.Email.Equals(objLoginModel.Email) && s.Password.Equals(objLoginModel.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginError = "Invalid UserName and Password";
                    return View();
                }
            }
            else
            {
                ViewBag.LoginError = "UserName and Password required";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}