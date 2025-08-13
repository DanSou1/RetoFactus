using Microsoft.AspNetCore.Mvc;
using RetoFactus.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace RetoFactus.Services
{
    public class RangeIdService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;

        public RangeIdService( IMemoryCache memoryCache, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _memoryCache = memoryCache;
            _configuration = configuration;
        }

        public async Task<RootNumberRange> RangeId()
        {
            var token = _memoryCache.Get<string>("accessToken");
            var url = _configuration["ApiSettings:Url"];
            string fullUrl = 
                $"{url.TrimEnd('/')}/v1/numbering-ranges?filter[id]" +
                $"&filter[document]" +
                $"&filter[resolution_number]" +
                $"&filter[technical_key]" +
                $"&filter[is_active]";

            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
            request.Headers.Authorization = new("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var numberRange = JsonSerializer.Deserialize<RootNumberRange>(json);
            return numberRange;
        }
    }
}
