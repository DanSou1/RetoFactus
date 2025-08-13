using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using RetoFactus.Models;
using System.Text;
using System.Text.Json;

namespace RetoFactus.Services
{
    public class CreateBillService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;

        public CreateBillService(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _memoryCache = memoryCache;
            _configuration = configuration;
        }

        public async Task<DetailBillModel> CreateBill(DetailBillModel detailBillModel, string identification)
        {
            string document = "1";
            var url = _configuration["ApiUrl"] + "/api/v1/bills/validate";
            detailBillModel.reference_code = $"FACT-{DateTime.UtcNow:yyyyMMddHHmmssfff}";
            var jsonBill = JsonSerializer.Serialize(detailBillModel);
            var content = new StringContent(jsonBill, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            
            if (response.IsSuccessStatusCode)
            { 
                var responseJson = await response.Content.ReadAsStringAsync();
                var detailBill = JsonSerializer.Deserialize<DetailBillModel>(responseJson);
                return detailBill;
            }
            else
            {
                throw new Exception("No se creo la factura");
            }
        }
    }
}
