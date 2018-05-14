using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatlogServiceApi.Models
{
    public class Brands:BaseClass
    {
        public int Id { get; set; }
        public string Brandname { get; set; }
    }
}