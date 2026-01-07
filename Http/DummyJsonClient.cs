using System.Net.Http.Json;
using backend.Models;
using System.Text.Json;
 
namespace backend.Http;

public class DummyJsonClient
{
    private readonly HttpClient _httpClient;

    public DummyJsonClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://dummyjson.com/");
    }

    public async Task<ProductListResponse> GetProductsAsync(int limit = 10, int skip = 0)
    {
        try
        {
            var response = await _httpClient.GetAsync($"products?limit={limit}&skip={skip}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductListResponse>();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Error fetching products: {ex.Message}", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception($"Error deserializing products response: {ex.Message}", ex);
        }
    }

    public async Task<Product> GetProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Error fetching product {id}: {ex.Message}", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception($"Error deserializing product response: {ex.Message}", ex);
        }
    }
}