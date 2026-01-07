using backend.Http;
using backend.Models;

namespace backend.Services;

public class ProductService
{
    private readonly DummyJsonClient _dummyJsonClient;

    public ProductService(DummyJsonClient dummyJsonClient)
    {
        _dummyJsonClient = dummyJsonClient;
    }

    public async Task<ProductListResponse> GetPaginatedProductsAsync(int page, int pageSize)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        int skip = (page - 1) * pageSize;
        return await _dummyJsonClient.GetProductsAsync(pageSize, skip);
    }

    public async Task<Product> GetProductAsync(int id)
    {
        return await _dummyJsonClient.GetProductAsync(id);
    }
}