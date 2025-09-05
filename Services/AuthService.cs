using Microsoft.Extensions.Caching.Memory;
using NuGet.Common;
using RetoFactus.Controllers;
using RetoFactus.Models;
using System;
using System.IO;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace RetoFactus.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        public AuthService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _memoryCache = memoryCache;
        }

        public async Task<TokenResponse> GetAccesToken(string user, string pwd)
        {
            string fullUrl = "https://api-sandbox.factus.com.co/oauth/token";
            
            var requestData = new Dictionary<string, string>
            {
                {"grant_type", "password" },
                {"client_id", "9e40adfa-164d-40cf-88d9-97834a3849ef" },
                {"client_secret", "9npMuYmdNi9LD82x3D2YWurwvOx9kxhNjveycf5P" },
                {"username", user },
                {"password", pwd},
            };

            var request = new HttpRequestMessage(HttpMethod.Post, fullUrl)
            {
                Content = new FormUrlEncodedContent(requestData)
            };

            var response = await _httpClient.SendAsync(request);
            var errorContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new Exception("No se logro obtener el token " + response.StatusCode + "Error" + errorContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenData = JsonSerializer.Deserialize<TokenResponse>(responseContent);
            _memoryCache.Set("refreshToken", tokenData.refresh_token);
            _memoryCache.Set("accessToken", tokenData.access_token);
            return tokenData;
        }

        public async Task<TokenResponse> RefreshToken()
        {
            var clientId = _configuration["ApiSettings:ClientId"];
            var clientSecret = _configuration["ApiSettings:ClientSecret"];
            var refreshToken = "";
            _memoryCache.TryGetValue("refreshToken", out refreshToken);
            string url = "https://api-sandbox.factus.com.co/oauth/token";

            var requestData = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token" },
                {"client_id", clientId },
                {"client_secret", clientSecret },
                {"refresh_token", refreshToken }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(requestData)
            };

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<TokenResponse>(responseContent);
            
            return token;
        }
    }
}
