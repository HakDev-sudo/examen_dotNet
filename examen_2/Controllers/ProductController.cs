using examen_2.Models;
using examen_2.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace examen_2.Controllers;


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
    
    [HttpGet("{price}")]
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
    
}