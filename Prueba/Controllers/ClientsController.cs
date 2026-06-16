using Microsoft.AspNetCore.Mvc;
using Prueba.Services;

namespace Prueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }
    //1
    [HttpGet("filter/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        var result = await _clientService.FiltrarClientesPorNombreAsync(name);
        return Ok(result);
    }
    // 09(1)
    [HttpGet("pedidos-notracking")]
    public async Task<IActionResult> ObtenerClientesConPedidosNoTracking()
    {
        var resultado = await _clientService.ObtenerClientesYPedidosSinTrackingAsync();
        return Ok(resultado);
    }
    
    //09(3)
    [HttpGet("total-productos")]
    public async Task<IActionResult> ObtenerTotalProductosPorCliente()
    {
        var resultado = await _clientService.ObtenerClientesConTotalProductosAsync();
        return Ok(resultado);
    }
}