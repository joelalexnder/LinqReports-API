using Prueba.DTOs;

namespace Prueba.Services;

public interface IOrderDetailService
{
    //3
    Task<List<DetalleProductoDto>> ObtenerDetallePorOrdenAsync(int ordenId);
    //4
    Task<int> CalcularTotalProductosPorOrdenAsync(int ordenId);
    
    //10
    Task<List<PedidoCompletoDto>> ObtenerTodosLosPedidosConDetallesAsync();
    
    //12
    Task<List<string>> ObtenerNombresClientesPorProductoAsync(int productoId);
}