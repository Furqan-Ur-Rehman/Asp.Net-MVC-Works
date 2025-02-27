﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scaffold_Column.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        [ScaffoldColumn(false)]
        public string Contact { get; set; }

        [ScaffoldColumn(false)]
        public string Address{ get; set; }
    }
}