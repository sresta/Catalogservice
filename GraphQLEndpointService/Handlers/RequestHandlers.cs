using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GraphQLEndpointService.Handlers
{
    public class RequestHandlers : IRequestHandler
    {
        public async Task<TResponse> GetRequest<TResponse>(string url) where TResponse : new()
        {
            return await Task.Run(() => GetData<TResponse>(url));
        }

        public async Task<TResponse> SendRequest<TResponse>(string url, IDictionary<string, string> headers, string requestMethod) where TResponse : new()
        {
            return await Task.Run(() => GetData<TResponse>(url, headers, requestMethod));
        }

        public async Task<string> PostRequest<TRequest>(string url, IDictionary<string, string> headers, TRequest requestBody, string requestMethod)
            where TRequest : new()

        {
            return await Task.Run(() => PostData<TRequest>(url, headers, requestBody, requestMethod));
        }


        public TResponse GetData<TResponse>(string URL) where TResponse : new()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            if (!string.IsNullOrEmpty(response))
                            {
                                TResponse result = JsonConvert.DeserializeObject<TResponse>(response);
                                return result;

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

            return new TResponse();
        }

        private string PostData<TRequest>(string url, IDictionary<string, string> headers, TRequest requestBody, string requestMethod) where TRequest : new()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";
                request.Method = requestMethod;
                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    if (requestBody is string)
                    {
                        streamWriter.Write(requestBody);
                    }
                    else
                    {
                        string json = JsonConvert.SerializeObject(requestBody);
                        streamWriter.Write(json);
                    }
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }



        }

        private TResponse GetData<TResponse>(string URL, IDictionary<string, string> headers, string requestMethod) where TResponse : new()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = requestMethod;
            request.ContentType = "application/json";
            foreach (var item in headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            if (!string.IsNullOrEmpty(response))
                            {
                                TResponse result = JsonConvert.DeserializeObject<TResponse>(response);
                                return result;

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return new TResponse();
        }

    }
}
