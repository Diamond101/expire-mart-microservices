using Microsoft.AspNetCore.Mvc;
using ProductService.EventBus;
using ProductService.Events;
using ProductService.Model;


namespace ProductService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private static List<Product> _products = new();
    private readonly IEventBus _eventBus;

    public ProductsController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_products);

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product);

        await _eventBus.PublishAsync(new ProductCreatedEvent
        {
            ProductId = product.Id,
            Name = product.Name,
            ExpiryDate = product.ExpiryDate
        });

        return Ok(product);
    }
}