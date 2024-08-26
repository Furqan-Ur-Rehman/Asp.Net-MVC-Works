using Login_Logout_Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Login_Logout_Form.Controllers
{
    public class LoginController : Controller
    {
        Login_Logout_FormEntities db = new Login_Logout_FormEntities();
        // GET: Login
        public ActionResult Index()
        {
            HttpCookie Cookie = Request.Cookies["Username"];
            if (Cookie != null)
            {
                ViewBag.UserName = Cookie["UserName"].ToString();
                // This below code for decrypt password
                string EncryptPassword = Cookie["Password"].ToString();
                byte[] b = Convert.FromBase64String(EncryptPassword);
                string DecryptPassword = ASCIIEncoding.ASCII.GetString(b);
                ViewBag.Password = DecryptPassword.ToString();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User s)
        {
            HttpCookie Cookie = new HttpCookie("Username");
            if (ModelState.IsValid)
            {
                var data = db.Users.Where(model => model.Username == s.Username && model.Password == s.Password).FirstOrDefault();
                if(data == null)
                {
                    ViewData["LoginFailed"] = "Login Failed!!";
                }
                else{
                    if(s.Rememberme)
                    {

                        Cookie["UserName"] = s.Username;
                        //This code below for encrypted password.
                        byte[] b = ASCIIEncoding.ASCII.GetBytes(s.Password);
                        string EncryptedPassword = Convert.ToBase64String(b);
                        Cookie["Password"] = EncryptedPassword;
                        
                       
                        HttpContext.Response.Cookies.Add(Cookie);//This code is to store cookie in browser.
                        Cookie.Expires = DateTime.Now.AddDays(2);
                        Session["data"] = s.Username;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["data"] = s.Username;
                        Cookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Response.Cookies.Add(Cookie);
                        return RedirectToAction("Index", "Home");
                    }
                      
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }

    
}