using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Handlers
{
    public interface IRequestHandler
    {       
        Task<TResponse> GetRequest<TResponse>(string url) where TResponse : new();
        Task<TResponse> SendRequest<TResponse>(string url, IDictionary<string, string> headers, string requestMethod) where TResponse : new();
        Task<string> PostRequest<TRequest>(string url, IDictionary<string, string> headers, TRequest requestBody, string requestMethod) where TRequest : new();
    }
}
