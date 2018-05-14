using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatlogServiceApi.Connections;
using CatlogServiceApi.Implementation;
using CatlogServiceApi.Models;
using Nest;


namespace CatlogServiceApi.Controllers
{   
    public class ProductsController : ApiController
    {
        private ESConnection conn = new ESConnection();
        private ElasticHandler esrepo = new ElasticHandler();
        public string indexName = "products";
        Products product = new Products();
        private List<Products> list = new List<Products>();
        //GET api/values
        //public IEnumerable<Products> Get()
        //{
        //    ElasticClient es = conn.Update(indexName);
        //  var res = esrepo.GetDocument<Products>(es, product);
        //    foreach(var list in res)
        //    {

        //    }
        //    return rep;
        //}

        // GET api/values/5


        public object Get(int id)
        {
            ElasticClient es = conn.Update(indexName);
            return esrepo.GetDocumentById(es, id,product);
           
        }

        [HttpPost]
        // POST api/values
        public string Post([FromBody]Products products)
        {
            try
            {
                ElasticClient es = conn.Create();

                var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };

                var indexConfig = new IndexState
                {
                    Settings = settings
                };

                if (!es.IndexExists("products").Exists)
                {
                    es.CreateIndex("products", c => c
                    .InitializeUsing(indexConfig)                    
                    .Mappings(m => m.Map<Products>(mp => mp.AutoMap())));
                }
                
                esrepo.InsertDocument<Products>(es,products,"products");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/values/5
        [HttpPost]
        public object Put([FromBody]Products product, int id)
        {
           
            ElasticClient es = conn.Update(indexName);
            var response = esrepo.UpdateDocument(id,es,product,indexName);
            return response;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {            
            ElasticClient es = conn.Update(indexName);
            esrepo.DeleteDocument(es,id,product,indexName);
        }
    }
}
