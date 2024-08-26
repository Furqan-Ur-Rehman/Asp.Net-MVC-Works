using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using first_web_app.Models;

namespace first_web_app.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //"This Data transfer from this Index view to Temp_data view"

            ViewData["msg1"] = "This Message comes from ViewData.";
            ViewBag.msg2 = "This Message comes from ViewBag";

            //Current Request of TempData
            TempData["msg3"] = "This Message comes from TempData";

            Session["msg4"] = "This Message comes from Session";

            //Array
            string[] games = {"Hockey", "Baseball", "Cricket", "Football" };
            TempData["games_array"] = games;
            Session["games_array"] = games;

            //List
            TempData["languages_list"] = new List<string>()
            {
                "C#",
                "Asp.Net",
                "Php",
                "Html",
                "Css",
                "Javascript"
            };
            //return RedirectToAction("Temp_data");
            return View();
        }

        //Subsequent Request of TempData
        public ActionResult Temp_data()
        {
            if(TempData["msg3"] != null)
            {
                TempData["msg3"].ToString();
            }
            //TempData.Keep();
            return View();
        }

        public ActionResult Trans_data()
        {
            if (TempData["msg3"] != null)
            {
                TempData["msg3"].ToString();
            }
            return View();
        }

        public string Show()
        {
            return "This is a second action method!";
        }

        public ActionResult AboutUs()
        {
            //ViewData[""] is used for when data passes from controller to view

            ViewData["Message"] = "Asp.Net MVC";
            ViewData["current_time"] = DateTime.Now.ToLongTimeString();

            //Array
            string[] lang = { "C#", "Asp.Net MVC", "PHP", "Html", "Css", "Javascript" };
            ViewData["lang"] = lang;

            //List
            ViewData["fruits_list"] = new List<string>()
            {
                "Apple",
                "Banana",
                "Mango",
                "Water Melon"
            };

            //Object
            Employee emp = new Employee();
            emp.EmployeeId = 1001;
            emp.EmployeeName = "Furqan";
            emp.EmployeeDesig = "Sr. Software Engineer";

            ViewData["emp_obj"] = emp;

            return View();
        }


        public int StudentID(int id)
        {
            return id;
        }

        public ActionResult View_Baig()
        {
            //Single Data
            ViewBag.Message = "Asp.Net MVC";
            ViewBag.CurrentDate = DateTime.Now.ToLongDateString();

            //Array
            string[] lang = { "C#", "Asp.Net MVC", "PHP", "Html", "Css", "Javascript" };
            ViewBag.language = lang;

            //List
            ViewBag.fruits_list = new List<string>()
            {
                "Apple",
                "Banana",
                "Mango",
                "Water Melon"
            };


            //Object
            Employee emp = new Employee();
            emp.EmployeeId = 1001;
            emp.EmployeeName = "Furqan";
            emp.EmployeeDesig = "Sr. Software Engineer";

            ViewBag.Employee_Details = emp;


            ViewBag.commonmessage = "This message is accessible from both ViewBag and ViewData";
            return View();
        }

        
        
    }
}