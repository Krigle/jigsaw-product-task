namespace backend.Models;

public class ProductListResponse
{
    public List<Product> Products { get; set; } = new();
    public int Total { get; set; }
    public int Skip { get; set; }
    public int Limit { get; set; }
}

