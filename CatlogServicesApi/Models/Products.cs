using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatlogServiceApi.Models;

namespace CatlogServiceApi.Models
{ 

    public class Products:BaseClass
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }


}