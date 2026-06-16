using Microsoft.AspNetCore.Mvc;
using Prueba.Services;

namespace Prueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    //6

    [HttpGet("despues-de/{fecha}")]
    public async Task<IActionResult> ObtenerDespuesDeFecha(DateTime fecha)
    {
        var pedidos = await _orderService.ObtenerPedidosDespuesDeFechaAsync(fecha);
        return Ok(pedidos);
    }
    //9
    [HttpGet("cliente-top")]
    public async Task<IActionResult> ObtenerClienteTop()
    {
        var clienteTop = await _orderService.ObtenerClienteConMasPedidosAsync();

        return Ok(clienteTop);
    }
    
    //11
    [HttpGet("cliente/{clientId}/producto")]
    public async Task<IActionResult> ObtenerProductosPorCliente(int clientId)
    {
        var productos = await _orderService.ObtenerNombresProductosPorClienteAsync(clientId);
        return Ok(productos);
    }
    
    // 09(2)
    [HttpGet("detalle")]
    public async Task<IActionResult> ObtenerDetallesCompletos()
    {
        var resultado = await _orderService.ObtenerPedidosConDetallesYProductosAsync();
        return Ok(resultado);
    }
    // 09(4)
    [HttpGet("ventas/cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerReporteVentasPorCliente([FromRoute] int clienteId)
    {
        var resultado = await _orderService.ObtenerVentasPorClienteAsync(clienteId);
        return Ok(resultado);
    }
    
    
    
    
    
    
    
    
    
    
    
    
}