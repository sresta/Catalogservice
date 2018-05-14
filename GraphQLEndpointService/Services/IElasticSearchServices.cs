using GraphQLEndpointService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Services
{
    public interface IElasticSearchServices
    {
        T GetByIndex<T>(string indexName) where T : new();
        T GetById<T>(int id, string indexName) where T : new();
        T GetByName<T>(string name, string indexName) where T : new();
    }
}
