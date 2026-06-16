using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Repository;

public interface IClientRepository
{
    Task<List<Client>> ObtenerClientesPorNombreAsync(String name);
    
    // 09(1)
    Task<List<ClientOrderDto>> ObtenerClientesYPedidosSinTrackingAsync();
    
    // 09(3)
    Task<List<ClienteTotalProductosDto>> ObtenerClientesConTotalProductosAsync();
    
}