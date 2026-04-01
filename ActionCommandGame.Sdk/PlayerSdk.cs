using System.Net.Http.Json;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Filters;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Sdk
{
    public class PlayerSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ActionCommandGameApi");

        public async Task<ServiceResult<PlayerResult>?> Get(int id)
        {
            var response = await _httpClient.GetAsync($"api/player/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResult<PlayerResult>>();
        }

        public async Task<ServiceResult<IList<PlayerResult>>?> Find()
        {
            var response = await _httpClient.GetAsync("api/player");
            return await response.Content.ReadFromJsonAsync<ServiceResult<IList<PlayerResult>>>();
        }
    }
}