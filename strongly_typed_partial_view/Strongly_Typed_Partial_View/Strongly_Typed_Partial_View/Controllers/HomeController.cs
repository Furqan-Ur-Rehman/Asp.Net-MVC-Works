using Strongly_Typed_Partial_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strongly_Typed_Partial_View.Controllers
{
    public class HomeController : Controller
    {
        List<Product> ProductLists = new List<Product>()
        {
            new Product { Id  = 1, Name = "Mouse" , Price = 250.36, Picture = "~/images/mouse.png"},
            new Product { Id  = 2, Name = "Keyboard" , Price = 200.45, Picture = "~/images/keyboard.png"},
            new Product { Id  = 3, Name = "Laptop" , Price = 25000.00, Picture = "~/images/laptop.png"}
        };

        // GET: Home
        public ActionResult Index()
        {
            
            return View(ProductLists);
        }
    }
}