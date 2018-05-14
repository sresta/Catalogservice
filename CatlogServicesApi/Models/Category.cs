using CatlogServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatlogServiceApi.Models
{
    public class Category:BaseClass
    {
        public int Id { get; set; }
        public string Categoryname { get; set; }
    }
}