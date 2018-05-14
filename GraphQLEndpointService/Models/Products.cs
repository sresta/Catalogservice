using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Models
{
    public class ProductResult
    {
        public ProductHits hits { get; set; }
    }
    public class ProductHits
    {

        public List<ProductSource> hits { get; set; }

    }
    public class ProductSource
    {

        public Products _source { get; set; }
    }
    public class Products 
    {
        public int id { get; set; }
        public string productname { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}
