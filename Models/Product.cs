namespace backend.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Thumbnail { get; set; }
    public decimal Price { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<string> Images { get; set; } = new();
    public string ShippingInformation { get; set; }
}