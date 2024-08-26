using Data_Anotation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Anotation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee e)
        {
            if(ModelState.IsValid == true)
            {
                ViewData["data_submission"] = "<script>alert('Data Submitted Successfully!!')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}