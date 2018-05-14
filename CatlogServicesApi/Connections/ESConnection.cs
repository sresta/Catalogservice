using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatlogServiceApi.Connections
{
    public class ESConnection
    {
        public static Uri EsNode;
        public static ConnectionSettings EsConfig;
        public static ElasticClient EsClient;

        public ElasticClient Create()
        {
            EsNode = new Uri("http://localhost:9200/");
            EsConfig = new ConnectionSettings(EsNode);
            EsClient = new ElasticClient(EsConfig);
            return EsClient;
        }
        public ElasticClient Update(IndexName iname)
        {
            EsNode = new Uri("http://localhost:9200/");
            EsConfig = new ConnectionSettings(EsNode).DefaultIndex(iname.ToString());
            EsClient = new ElasticClient(EsConfig);
            return EsClient;
        }
    }
}