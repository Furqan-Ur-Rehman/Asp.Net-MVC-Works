using Strongly_typed_view.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strongly_typed_view.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Employee employee = new Employee();
            employee.Id = 001;
            employee.Name = "Furqan";
            employee.Age = 30;

            Employee employee1 = new Employee();
            employee1.Id = 002;
            employee1.Name = "Dua";
            employee1.Age = 25;

            Employee employee2 = new Employee();
            employee2.Id = 003;
            employee2.Name = "Adnan";
            employee2.Age = 29;

            List<Employee> employeeslist = new List<Employee>();
            
                employeeslist.Add(employee);
                employeeslist.Add(employee1);
                employeeslist.Add(employee2);

        

            ViewData["emp1"] = employee;
            ViewBag.emp2 = employee;
            return View(employeeslist);
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}