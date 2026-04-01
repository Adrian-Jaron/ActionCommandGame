using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Sdk
{
    public class PlayerItemSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ActionCommandGameApi");

        public async Task<ServiceResult<PlayerItemResult>?> Get(int id)
        {
            var response = await _httpClient.GetAsync($"api/playeritem/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResult<PlayerItemResult>?>();
        }

        public async Task<ServiceResult<IList<PlayerItemResult>>?> Find(int playerId)
        {
            var response = await _httpClient.GetAsync($"api/playeritem?playerId={playerId}");
            return await response.Content.ReadFromJsonAsync<ServiceResult<IList<PlayerItemResult>>>();
        }

        public async Task<ServiceResult<PlayerItemResult>?> Create(int playerId, int itemId)
        {
            var response = await _httpClient.PostAsync($"api/playeritem/{playerId}/{itemId}", null);
            return await response.Content.ReadFromJsonAsync<ServiceResult<PlayerItemResult>>();
        }

        public async Task<ServiceResult?> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/playeritem/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResult>();
        }

    }
}
