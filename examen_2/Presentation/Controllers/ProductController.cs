using examen_2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace examen_2.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly   IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
       var allProducts = await _productService.GetAllProducts();
        return Ok(allProducts); 
    }
    
    [HttpGet("price/{price}")]
    public async Task<IActionResult> GetAllProducWhitPrice(decimal price)
    {
        Console.WriteLine("Estoy recibiendo esto : ", price);
        var  producs = await _productService.ObtenerProductorMayorQue(price);
        
        if (producs == null) return NotFound();
        return Ok(producs);
    }

    [HttpGet("Orderby/{id}")]
    public async Task<IActionResult> GetProductsByOrderId(int id)
    {
        var products = await _productService.GetProductsByOrderId(id);
        if(products == null) return NotFound();
        return Ok(products);
    }
    
    [HttpGet("Order/{id}/total-quantity")]
    public async Task<IActionResult> GetTotalQuantityByOrder(int id)
    {
        var total = await _productService.GetTotalQuantityByOrderId(id);
        return Ok(total);
    }

    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensive()
    {
        var p = await _productService.GetMostExpensiveProduct();
        if (p == null) return NotFound();
        return Ok(p);
    }

    [HttpGet("order-details")]
    public async Task<IActionResult> GetAllOrderDetails()
    {
        var details = await _productService.GetOrderDetailsProductQuantity();
        return Ok(details);
    }

    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var avg = await _productService.GetAveragePrice();
        return Ok(avg);
    }

    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var prods = await _productService.GetProductsWithoutDescription();
        return Ok(prods);
    }

    [HttpGet("sold-to-client/{clientId}")]
    public async Task<IActionResult> GetProductsSoldToClient(int clientId)
    {
        var prods = await _productService.GetProductsSoldToClient(clientId);
        return Ok(prods);
    }

    [HttpGet("clients/most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var res = await _productService.GetClientWithMostOrders();
        return Ok(res);
    }

    [HttpGet("clients/who-bought/{productId}")]
    public async Task<IActionResult> GetClientsWhoBoughtProduct(int productId)
    {
        var names = await _productService.GetClientsWhoBoughtProduct(productId);
        return Ok(names);
    }
    
    [HttpGet("orders/after")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _productService.GetOrdersAfterDate(date);
        return Ok(orders);
    }
}