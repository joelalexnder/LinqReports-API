using Microsoft.AspNetCore.Mvc;
using Prueba.Services;

namespace Prueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;

    public OrderDetailsController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }
    //3
    [HttpGet("orden/{ordenId}")]
    public async Task<IActionResult> ObtenerPorOrden(int ordenId)
    {
        var resultado = await _orderDetailService.ObtenerDetallePorOrdenAsync(ordenId);
        return Ok(resultado);
    }
    //4
    [HttpGet("orden/{ordenId}/total-productos")]
    public async Task<IActionResult> CalcularTotalProductos(int ordenId)
    {
        var total = await _orderDetailService.CalcularTotalProductosPorOrdenAsync(ordenId);
    
        return Ok(new 
        { 
            OrdenId = ordenId, 
            TotalProductos = total 
        });
    }
    
    //10
    [HttpGet("todos-con-detalles")]
    public async Task<IActionResult> ObtenerTodosLosPedidos()
    {
        var resultado = await _orderDetailService.ObtenerTodosLosPedidosConDetallesAsync();
        return Ok(resultado);
    }
    
    //12
    [HttpGet("producto/{productoId}/clientes")]
    public async Task<IActionResult> ObtenerClientesPorProducto(int productoId)
    {
        var clientes = await _orderDetailService.ObtenerNombresClientesPorProductoAsync(productoId);

        return Ok(clientes);
    }
    
    
    
}