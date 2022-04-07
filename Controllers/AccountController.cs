using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account  //for login purpose:
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(UserModel obj)
        {
            using(var context = new universityEntities1())
            {
                bool isValid = context.users.Any(x=>x.Username == obj.Username && x.Password == obj.Password );

                if (isValid)
                {

                    FormsAuthentication.SetAuthCookie(obj.Username, false);

                    return RedirectToAction("Index", "student_regform");
                }

                //for showing the error message
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }

           
        }


        //For Sign Up Page
        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(user obj)
        {

            using (var context = new universityEntities1())  //take data from Entity model
            {
                context.users.Add(obj); //Add the signup data 
                context.SaveChanges();
            }


            return RedirectToAction("login"); //then redirect to Login page
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

    }
}