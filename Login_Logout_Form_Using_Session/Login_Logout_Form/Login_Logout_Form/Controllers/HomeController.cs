using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Logout_Form.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Retreive Cookie below code
            HttpCookie cookie = Request.Cookies["Username"];

            if(Session["data"] == null && cookie == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if(cookie != null)
                {
                    ViewBag.Cookie_Value = Request.Cookies["Username"].Value.ToString();
                }
                
            }
            return View();
        }
    }
}