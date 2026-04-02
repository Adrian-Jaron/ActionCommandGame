using System.Net.Http.Json;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Sdk
{
    public class GameSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ActionCommandGameApi");

        public async Task<ServiceResult<GameResult>?> PerformAction(int playerId)
        {
            var response = await _httpClient.GetAsync($"api/game/perform-action/{playerId}");
            return await response.Content.ReadFromJsonAsync<ServiceResult<GameResult>>();
        }

        public async Task<ServiceResult<BuyResult>?> Buy(int playerId, int itemId)
        {
            var response = await _httpClient.PostAsync($"api/game/buy/{playerId}/{itemId}", null);
            return await response.Content.ReadFromJsonAsync<ServiceResult<BuyResult>>();
        }
    }
}