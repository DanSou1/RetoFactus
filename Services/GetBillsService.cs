using Microsoft.Extensions.Caching.Memory;
using RetoFactus.Models;
using System.Text.Json;


namespace RetoFactus.Services
{
    public class GetBillsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        public GetBillsService(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _memoryCache = memoryCache;
            _configuration = configuration;
        }

        public async Task<BillsResponse> GetAllBills()
        {
            var token = _memoryCache.Get<string>("accessToken");
            string fullUrl =
                "https://api-sandbox.factus.com.co/v1/bills?filter[identification]&filter[names]&filter[number]&filter[prefix]&filter[reference_code]&filter[status]";
            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
            request.Headers.Authorization = new("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var billsResponse = JsonSerializer.Deserialize<BillsResponse>(json, options);

            return billsResponse;
        }
    }
}
