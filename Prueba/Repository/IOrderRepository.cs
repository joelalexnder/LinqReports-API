using Prueba.Models;
using Prueba.DTOs;

namespace Prueba.Repository;

public interface IOrderRepository
{
    //6
    Task<List<Order>> ObtenerPedidosDespuesDeFechaAsync(DateTime fecha);
    
    //9
    Task<ClienteMasPedidosDto> ObtenerClienteConMasPedidosAsync();
    
    //11
    Task<List<string>> ObtenerNombresProductosPorClienteAsync(int clientId);
    
    // 09(2)
    Task<List<OrderDetailsDto>> ObtenerPedidosConDetallesYProductosAsync();
    
    // 09(4)
    Task<List<SalesByClientDto>> ObtenerVentasPorClienteAsync(int id);
}
