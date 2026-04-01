using ActionCommandGame.Services.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;
using ActionCommandGame.Services.Model.Results;
using System.Net.Http.Json;

namespace ActionCommandGame.Sdk
{
    public class ItemSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ActionCommandGameApi");

        public async Task<ServiceResult<ItemResult>?> Get(int id)
        {
            var response = await _httpClient.GetAsync($"api/item/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResult<ItemResult>>();

        }

        public async Task<ServiceResult<IList<ItemResult>>?> Find()
        {
            var response = await _httpClient.GetAsync($"api/item");
            return await response.Content.ReadFromJsonAsync<ServiceResult<IList<ItemResult>>>();
        }
    }
}
