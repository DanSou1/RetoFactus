namespace RetoFactus.Services;
using RetoFactus.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;


public class MunicipalitiesService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _memoryCache;
    private readonly IConfiguration _configuration;

    public MunicipalitiesService(IMemoryCache memoryCache, IConfiguration configuration )
    {
        _httpClient = new HttpClient();
        _memoryCache = memoryCache;
        _configuration = configuration;
    }
    public async Task<MunicipalitiesModel> Municipalities()
    {
        var url = _configuration["ApiSettings:Url"];
        var fullUrl = $"{url.TrimEnd('/')}/v1/municipalities";
        var token = _memoryCache.Get<string>("accessToken");
        var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
        request.Headers.Authorization = new("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var municipalitiesJson = await response.Content.ReadAsStringAsync();
        var json = JsonSerializer.Deserialize<MunicipalitiesModel>(municipalitiesJson);

        return json;
    }
}
