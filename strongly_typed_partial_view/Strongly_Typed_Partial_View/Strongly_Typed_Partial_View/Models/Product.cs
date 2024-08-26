using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strongly_Typed_Partial_View.Models
{
    public class Product
    {
        //auto implemented property
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
    }
}