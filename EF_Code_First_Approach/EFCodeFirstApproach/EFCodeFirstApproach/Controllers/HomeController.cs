using EFCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            ViewData["dispaydata"] = data;
            return View(data);
        }

        public ActionResult AboutUs()
        {
            var data1 = db.students.ToList();
            return View(data1);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students S)
        {
            if(ModelState.IsValid)
            {
                db.students.Add(S);
                int a = db.SaveChanges(); /* this Save.Changes() function 
                             * return 1 in case Data inserted otherwise 0 in case not inserted*/
                if (a > 0)
                {
                    //ViewBag.InsertData = "<script>alert('Data Inserted!!')</script>";
                    TempData["InsertData"] = "<script>alert('Data Inserted!!')</script>";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {

                    ViewBag.InsertData = "<script>alert('Data is not Inserted!!')</script>";
                }

            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Students s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["update"] = "<script>alert('Data has been Updated!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["update"] = "<script>alert('Data has not been Updated!!')</script>";
                }
            }
            
            return View();
        }

        public ActionResult Delete(int id)
        {
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(Students S)
        {
            db.Entry(S).State = System.Data.Entity.EntityState.Deleted;
            int a = db.SaveChanges();
            if(a > 0)
            {
                TempData["DataDeleted"] = "Data Deleted!!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DataDeleted = "Data is not Deleted!!";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
    }
}