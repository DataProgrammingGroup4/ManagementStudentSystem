using ManagementStudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudentSystem.Controllers
{
    public class LoginController : Controller
    {
        StudentEntities studentEntities = new StudentEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objchk)
        {
            if (ModelState.IsValid)
            {
                using (StudentEntities studentEntities = new StudentEntities())
                {
                    var obj = studentEntities.Users.Where(a => a.Username.Equals(objchk.Username) && a.Password.Equals(objchk.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("Index", "Registration");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password is Incorrect");
                    }
                }
            }


            return View(objchk);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }


    }
}