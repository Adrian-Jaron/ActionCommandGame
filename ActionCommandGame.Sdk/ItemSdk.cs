using System.Net.Http.Json;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;


namespace ActionCommandGame.Sdk
{
    public class ItemSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ActionCommandGameApi");

        public async Task<ServiceResult<IList<ItemResult>>?> Find()
        {
            var response = await _httpClient.GetAsync("api/item");
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Api response: {content}");
            return System.Text.Json.JsonSerializer.Deserialize<ServiceResult<IList<ItemResult>>>(content);
        }
        }
    }
