using Prueba.DTOs;
using Prueba.Models;
using Prueba.Repository;

namespace Prueba.Services.Implements;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    //6
    public async Task<List<Order>> ObtenerPedidosDespuesDeFechaAsync(DateTime fecha)
    {
        return await _unitOfWork.Orders.ObtenerPedidosDespuesDeFechaAsync(fecha);
    }
    
    //9
    public async Task<ClienteMasPedidosDto> ObtenerClienteConMasPedidosAsync()
    {
        return await _unitOfWork.Orders.ObtenerClienteConMasPedidosAsync();
    }
    
    //11
    public async Task<List<string>> ObtenerNombresProductosPorClienteAsync(int clientId)
    {
        return await _unitOfWork.Orders.ObtenerNombresProductosPorClienteAsync(clientId);
    }
    
    //09(2)
    public async Task<List<OrderDetailsDto>> ObtenerPedidosConDetallesYProductosAsync()
    {
        return await _unitOfWork.Orders.ObtenerPedidosConDetallesYProductosAsync();
    }
    
    //09(4)
    public async Task<List<SalesByClientDto>> ObtenerVentasPorClienteAsync(int id)
    {
        return await _unitOfWork.Orders.ObtenerVentasPorClienteAsync(id);
    }
    
    
    
    
    
    
    
    
    
    
    
    
}