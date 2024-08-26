using EFDatabase_FirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDatabase_FirstApproach.Controllers
{
    public class HomeController : Controller
    {
        DBFirstApproachEntities db = new DBFirstApproachEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["Inserted"] = "<script>alert('Data Inserted!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Inserted = "<script>alert('Data is not Inserted!!')</script>";
                }

            }
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["Updated"] = "<script>alert('Data Updated!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Updated"] = "<script>alert('Data is not Updated!!')</script>";
                }

            }
            
            return View();
        }

        public ActionResult Delete(int id)
        {
            var row = db.Students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
            int a = db.SaveChanges();
            if(a > 0)
            {
                TempData["Deleted"] = "Data Deleted!!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Deleted"] = "Data is not Deleted!!";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }
    }
}