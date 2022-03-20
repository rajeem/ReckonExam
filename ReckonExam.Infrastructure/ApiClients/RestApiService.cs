using Newtonsoft.Json;
using ReckonExam.Core.Api;
using ReckonExam.Core.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ReckonExam.Infrastructure.ApiClients
{
    public class RestApiService : IRestApiService
    {
        public async Task<T> Get<T>(string uri) where T : ApiResponse
        {
            T model;

            do
            {
                var client = new HttpClient();
                var response = await client.GetAsync(uri);
                var str = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<T>(str);
                model.IsSuccessStatusCode = response.IsSuccessStatusCode;
            } while (!model.IsSuccessStatusCode);

            return model;
        }

        public async Task<HttpResponseMessage> Post<T>(string uri, T obj)
        {
            HttpResponseMessage response;

            do
            {
                var client = new HttpClient();
                response = await client.PostAsJsonAsync(uri, obj);
            } while (!response.IsSuccessStatusCode);

            return response;
        }
    }
}
