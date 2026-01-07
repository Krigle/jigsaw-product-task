using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductService _productService;

    public HomeController(ILogger<HomeController> logger, ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        try
        {
            var products = await _productService.GetPaginatedProductsAsync(page, pageSize);
            return View(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving paginated products");
            return StatusCode(500, "Internal server error");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var product = await _productService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving product with id {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
