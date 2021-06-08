using Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class ConectionAPI
    {
        private string uri;

        public ConectionAPI(string _uri)
        {
            uri = _uri;
        }

        public async Task<TUsers> GetTUserLogin(string Email, string Password)
        {
            var client = new RestClient(uri + "getLogin?Email=" + Email + "&Password=" + Password);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<TUsers>(response.Content);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
