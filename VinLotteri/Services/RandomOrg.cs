using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using VinLotteri.Models;

namespace VinLotteri.Services
{
    public class RandomOrg : IRandom
    {
        private RestClient restClient;
        private string apiKey;
        public RandomOrg(string apiKey)
        {
            this.restClient = new RestClient("https://api.random.org");
            this.apiKey = apiKey;
        }
        public async Task<List<int>> getRandomNumbers(int from, int to, int size, bool replacement = false)
        {
            var requestBody = prepareRequestBody(from, to, size, replacement);
            var request = new RestRequest("/json-rpc/2/invoke", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            
            var cancellationTokenSource = new CancellationTokenSource();
            var response = await restClient.ExecuteTaskAsync<Response>(request, cancellationTokenSource.Token);

            return response.Data.result.random.data.Select(d => Int32.Parse(d)).ToList();
        }
        
        private string ReadResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private string prepareRequestBody(int from, int to, int size, bool replacement = false)
        {
            var template = ReadResource("VinLotteri.requestTemplate.json");
            return template.Replace("{from}", from.ToString())
                .Replace("{apiKey}", apiKey)
                .Replace("{to}", to.ToString())
                .Replace("{size}", size.ToString())
                .Replace("{replacement}", replacement.ToString().ToLower());
        }
    }
}