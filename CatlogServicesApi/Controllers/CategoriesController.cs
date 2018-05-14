using CatlogServiceApi.Connections;
using CatlogServiceApi.Implementation;
using CatlogServiceApi.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatlogServiceApi.Controllers
{
    public class CategoriesController : ApiController
    {
        public string indexName = "categories";
        private ESConnection conn = new ESConnection();
        private ElasticHandler esrepo = new ElasticHandler();
        Category category = new Category();

        [HttpPost]
        public string Post([FromBody]Category category)
        {
            try
            {
                ElasticClient es = conn.Create();

                var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };

                var indexConfig = new IndexState
                {
                    Settings = settings
                };

                if (!es.IndexExists("categories").Exists)
                {
                    es.CreateIndex("categories", c => c
                    .InitializeUsing(indexConfig)
                    .Mappings(m => m.Map<Category>(mp => mp.AutoMap())));
                }

                esrepo.InsertDocument<Category>(es, category , "categories");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public object Put([FromBody]Category category, int id)
        {

            ElasticClient es = conn.Update(indexName);
            var response = esrepo.UpdateDocument(id, es, category, indexName);
            return response;
        }


        public void Delete(int id)
        {
            
            ElasticClient es = conn.Update(indexName);
            esrepo.DeleteDocument(es, id, category, indexName);
        }
        public object Get(int id)
        {
            ElasticClient es = conn.Update(indexName);
            return esrepo.GetDocumentById(es, id, category);

        }
    }
}
