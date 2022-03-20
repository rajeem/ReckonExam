using ReckonExam.Core.Api;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReckonExam.Core.Interfaces
{
    public interface IRestApiService
    {
        public Task<T> Get<T>(string uri) where T : ApiResponse;
        public Task<HttpResponseMessage> Post<T>(string uri, T obj);
    }
}
