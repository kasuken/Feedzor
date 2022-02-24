using Feedzor.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Feedzor.Client.Services
{
    public class FeedzorService : IFeedzorService
    {
        HttpClient _httpClient;

        public FeedzorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FeedDetailsPageModel> GetRssById(string id)
        {
            var model = await _httpClient.GetFromJsonAsync<FeedDetailsPageModel>($"Feedzor/GetRssById/{id}");
            return model;
        }
    }
}
