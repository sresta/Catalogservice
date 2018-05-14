using Nest;
using CatlogServiceApi.Interface;
using CatlogServiceApi.Models;

namespace CatlogServiceApi.Implementation
{
    public class ElasticHandler :IElasticHandler
    {
        public void InsertDocument<T>(ElasticClient es, T emp,IndexName name) where T: BaseClass
        {
            es.Index<T>(emp,x => x
            .Index(name)); 
        }
        public object UpdateDocument<T>(int id, ElasticClient es,T obj,IndexName name) where T: BaseClass
        {            
            var response = es.Update(DocumentPath<T>
                .Id(id),
                u => u
                    .Index(name)                    
                    .DocAsUpsert(true)
                    .Doc(obj));
            return response;
        }
        public object DeleteDocument<T>(ElasticClient es, int id, T obj, IndexName name) where T : BaseClass
        {
            var response = es.Delete<T>(id, d => d.Index(name));
            return response;
        }
        
        public object GetDocumentById<T>(ElasticClient es,int id,T obj) where T:BaseClass
        {
            var response = es.Get<T>(id, d => d.Index("products"));
            return response.Source;
        }

        //public object GetDocument<T>(ElasticClient es, T obj) where T : BaseClass
        //{
        //    var response = es.GetIndex<T>();
        //    return response.Source;
        //}


    }
}