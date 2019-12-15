using System;
using System.IO;
using System.Net.Http;

using System.Threading.Tasks;
using Tester.Client.Interfaces;
using Tester.Client.Models;

namespace Tester.Client.Provider
{
    public class RestProvider : BaseProvider<Product, Category>
    {
        private static HttpClient _client;
        protected static HttpClient Client { get => _client ?? (_client = new HttpClient()); }

        public RestProvider(string uri) 
        {
            Client.BaseAddress = new Uri(uri);
        }
        public override IResponse<Product, Category> GetResponse()
        {
            var response = Client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Response>().Result;
            }
            return null;
        }
    }
}
