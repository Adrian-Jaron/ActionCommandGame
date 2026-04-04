using System.Net.Http.Json;
using ActionCommandGame.Services.Model.Requests;

namespace ActionCommandGame.Sdk
{
    public class AuthSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ActionCommandGameApi");

        public async Task<string?> Register(UserRegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/register", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
        
        public async Task<string?> Login(UserSignInRequest request) { 
        
            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", request);
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResult>();
                return result?.Token;
            }

            return null;
        }

    }

    public class TokenResult
    {
        public string Token { get; set; }
    }
}
