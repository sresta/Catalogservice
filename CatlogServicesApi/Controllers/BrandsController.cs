using CatlogServiceApi.Implementation;
using CatlogServiceApi.Connections;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatlogServiceApi.Models;

namespace CatlogServiceApi.Controllers
{
    public class BrandsController : ApiController
    {
        private ESConnection conn = new ESConnection();
        private ElasticHandler esrepo = new ElasticHandler();
        public string indexName = "brands";
        Brands brand = new Brands();


        [HttpPost]
        //POST api/values
        public string Post([FromBody]Brands brand)
        {
            try
            {
                ElasticClient es = conn.Create();

                var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };

                var indexConfig = new IndexState
                {
                    Settings = settings
                };

                if (!es.IndexExists("brands").Exists)
                {
                    es.CreateIndex("brands", c => c
                    .InitializeUsing(indexConfig)
                    .Mappings(m => m.Map<Brands>(mp => mp.AutoMap())));
                }
                esrepo.InsertDocument<Brands>(es, brand,"brands");

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public object Put([FromBody]Brands brand, int id)
        {

            ElasticClient es = conn.Update(indexName);
            var response = esrepo.UpdateDocument(id, es, brand, indexName);
            return response;
        }


        public void Delete(int id)
        {
            ElasticClient es = conn.Update(indexName);
            esrepo.DeleteDocument(es, id, brand, indexName);
        }
        public object Get(int id)
        {
            ElasticClient es = conn.Update(indexName);
            return esrepo.GetDocumentById(es, id, brand);

        }
    }
}
