using Prueba.DTOs;
using Prueba.Repository;

namespace Prueba.Services.Implements;

public class OrderDetailService : IOrderDetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    //3
    public async Task<List<DetalleProductoDto>> ObtenerDetallePorOrdenAsync(int ordenId)
    {
        return await _unitOfWork.OrderDetails.ObtenerDetallePorOrdenAsync(ordenId);
    }
    
    //4
    public async Task<int> CalcularTotalProductosPorOrdenAsync(int ordenId)
    {
        return await _unitOfWork.OrderDetails.CalcularTotalProductosPorOrdenAsync(ordenId);
    }
    
    //10
    public async Task<List<PedidoCompletoDto>> ObtenerTodosLosPedidosConDetallesAsync()
    {
        return await _unitOfWork.OrderDetails.ObtenerTodosLosPedidosConDetallesAsync();
    }
    
    //12
    public async Task<List<string>> ObtenerNombresClientesPorProductoAsync(int productoId)
    {
        return await _unitOfWork.OrderDetails.ObtenerNombresClientesPorProductoAsync(productoId);
    }
    
    
    
    
    
    
}