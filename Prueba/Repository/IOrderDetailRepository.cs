using Prueba.DTOs;

namespace Prueba.Repository;

public interface IOrderDetailRepository
{
    // 3
    Task<List<DetalleProductoDto>> ObtenerDetallePorOrdenAsync(int ordenId);
    //4    
    Task<int> CalcularTotalProductosPorOrdenAsync(int ordenId);
    
    //10
    Task<List<PedidoCompletoDto>> ObtenerTodosLosPedidosConDetallesAsync();
    
    //12
    Task<List<string>> ObtenerNombresClientesPorProductoAsync(int productoId);
    
}