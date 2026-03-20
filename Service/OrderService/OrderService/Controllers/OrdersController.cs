using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private static List<string> _orders = new();

    [HttpGet]
    public IActionResult Get() => Ok(_orders);

    [HttpPost]
    public IActionResult Create(string order)
    {
        _orders.Add(order);
        return Ok(order);
    }
}