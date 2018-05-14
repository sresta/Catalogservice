using GraphQLEndpointService.Handlers;
using GraphQLEndpointService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Services
{
    public class ResultSet
    {
        private RequestHandlers es = new RequestHandlers();
        //products
        public dynamic Getall()
        {
            var obj = es.GetData<Products>("http://localhost:9200/products/_search/?pretty=true");
            return obj;
        }
        public dynamic GetById(string id)
        {
            var obj = es.GetData<ProductResult>("http://localhost:9200/products/_search/?q=" + id);
            return obj;
        }
        public dynamic GetByName(string name)
        {
            var obj = es.GetData<ProductResult>("http://localhost:9200/products/_search/?q=" + name);
            return obj;
        }


        //Brands
        public dynamic GetallBrand()
        {
            var obj = es.GetData<BrandResult>("http://localhost:9200/brands/_search/?pretty=true");
            return obj;
        }
        public dynamic GetByIdBrand(string id)
        {
            var obj = es.GetData<BrandResult>("http://localhost:9200/brands/_search/?q=" + id);
            return obj;
        }
        public dynamic GetByNameBrand(string name)
        {
            var obj = es.GetData<BrandResult>("http://localhost:9200/brands/_search/?q=" + name);
            return obj;
        }


        //Categories
        public dynamic GetallCategory()
        {
            var obj = es.GetData<CategoryResult>("http://localhost:9200/categories/_search/?pretty=true");
            return obj;
        }
        public dynamic GetByIdCategory(string id)
        {
            var obj = es.GetData<CategoryResult>("http://localhost:9200/categories/_search/?q=" + id);
            return obj;
        }
        public dynamic GetByNameCategory(string name)
        {
            var obj = es.GetData<CategoryResult>("http://localhost:9200/categories/_search/?q=" + name);
            return obj;
        }
    }
}
