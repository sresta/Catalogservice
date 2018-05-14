using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Models
{
    public class CategoryResult
    {
        public CategoryHits hits { get; set; }
    }

    public class CategoryHits
    {
        public List<CategorySource> hits { get; set; }
    }

    public class CategorySource
    {
        public Category _source { get; set; }

    }

    public class Category
    {
        public int id { get; set; }
        public string categoryname { get; set; }
    }
}
