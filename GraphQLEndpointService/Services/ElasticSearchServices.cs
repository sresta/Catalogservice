
using GraphQLEndpointService.Handlers;
using GraphQLEndpointService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Services
{
    public class ElasticSearchServices : IElasticSearchServices
    {
        private RequestHandlers req = new RequestHandlers();         

        public T GetByIndex<T>(string indexName) where T:new()
        {

            var jsondata = req.GetData<T>("http://localhost:9200/" + indexName + "/_search?pretty=true");
            return jsondata;
        }
        public T GetById<T>(int id,string indexName) where T:new()
        {
            var jsondata = req.GetData<T>("http://localhost:9200/" + indexName + "/_search?pretty=true&q=" + id);
            return jsondata;
        }
        public T GetByName<T>(string name, string indexName) where T : new()
        {
            return req.GetData<T>("http://localhost:9200/" + indexName + "/_search?pretty=true" + name);
        }
    }
}
