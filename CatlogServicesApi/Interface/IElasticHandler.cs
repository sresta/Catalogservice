using CatlogServiceApi.Models;
using Nest;

namespace CatlogServiceApi.Interface
{

    public interface IElasticHandler
    {
        void InsertDocument<T>(ElasticClient es,T obj,IndexName name) where T: BaseClass;
        object UpdateDocument<T>(int id, ElasticClient es, T obj, IndexName name) where T : BaseClass;
        object DeleteDocument<T>(ElasticClient es, int id, T obj, IndexName name) where T : BaseClass;
        //object DeleteIndex(ElasticClient es);
        object GetDocumentById<T>(ElasticClient es, int id, T obj) where T : BaseClass;
    }

}
