using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Models
{
    public class BrandResult
    {
        public BrandHits hits { get; set; }
    }

    public class BrandHits
    {
        public List<BrandSource> hits { get; set; }
    }
    public class BrandSource
    {

        public Brands _source { get; set; }
    }
    public class Brands
    { 
        public int id { get; set; }
        public string brandname { get; set; }
    }
}
