using Microsoft.AspNetCore.Mvc;
using Prueba.Services;

namespace Prueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductosController(IProductService productService)
    {
        _productService = productService;
    }
    //2
    [HttpGet("precio-mayor-a/{price}")]
    public async Task<IActionResult> Get(decimal price)
    {
        var result = await _productService.FilterProductsByPriceAsync(price);
        return Ok(result);
    }
    
    //5
    [HttpGet("mas-caro")]
    public async Task<IActionResult> ObtenerMasCaro()
    {
        var producto = await _productService.ObtenerProductoMasCaroAsync();
        return Ok(producto);
    }
    
    //7
    [HttpGet("promedio-precio")]
    public async Task<IActionResult> CalcularPromedioPrecio()
    {
        var promedio = await _productService.CalcularPromedioPreciosAsync();
    
        return Ok(new 
        { 
            PromedioPrecio = promedio 
        });
    }
    
    //8
    [HttpGet("sin-descripcion")]
    public async Task<IActionResult> ObtenerSinDescripcion()
    {
        var productos = await _productService.ObtenerProductosSinDescripcionAsync();
        return Ok(productos);
    }
    
    
    
    
    
    
    
    
    
}