using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Services;

public interface IClientService
{
    //1
    Task<List<Client>> FiltrarClientesPorNombreAsync(string name);
    
    //09(1)
    Task<List<ClientOrderDto>> ObtenerClientesYPedidosSinTrackingAsync();
    
    //09(3)
    Task<List<ClienteTotalProductosDto>> ObtenerClientesConTotalProductosAsync();
}