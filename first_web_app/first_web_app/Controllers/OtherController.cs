using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace first_web_app.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public ActionResult Index()
        {
            if (TempData["msg3"] != null)
            {
                TempData["msg3"].ToString();
            }
            return View();
        }
    }
}