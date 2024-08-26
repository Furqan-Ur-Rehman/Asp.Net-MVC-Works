using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Validations_message.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string fullname, string Age, string Email)
        {
            string EmailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if(fullname.Equals("") == true)
            {
                ModelState.AddModelError("fullname", "Name is required!!");
                ViewData["NameError"] = "***";
            }
            if (Age.Equals(""))
            {
                ModelState.AddModelError("Age", "Age is required!!");
                ViewBag.AgeError = "***";
            }
            if (Email.Equals("") == true)
            {
                ModelState.AddModelError("Email", "Email is required!!");
                TempData["EmailError"] = "***";
            }
            else
            {
                if (Regex.IsMatch(Email, EmailPattern) == false)
                {
                    ModelState.AddModelError("Email", "Invalid Email!!");
                    TempData["EmailError"] = "***";
                }
            }
            if (ModelState.IsValid)
            {
                TempData["SuccessMessge"] = "<script>alert('Data has been Successfully Submitted!!')</script>";
                ModelState.Clear();
            }
            
            return View();
        }
    }
}