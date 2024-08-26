using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Strongly_Typed_Html_Helper.Models;

namespace Strongly_Typed_Html_Helper.Controllers
{
    public class HouseController : Controller
    {
        // GET: House
        public ActionResult House()
        {
            return View();
        }

        [HttpPost]
        public ActionResult House(Calculations c)
        {
            int num1 = c.Num1;
            int num2 = c.Num2;
            int result = num1 + num2;
            ViewBag.result = result;
            
            return View();
        }
    }
}