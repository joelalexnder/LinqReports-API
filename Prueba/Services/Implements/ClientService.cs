using Prueba.DTOs;
using Prueba.Models;
using Prueba.Repository;

namespace Prueba.Services.Implements;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    //1
    public async Task<List<Client>> FiltrarClientesPorNombreAsync(string name)
    {
        return await _unitOfWork.Clients.ObtenerClientesPorNombreAsync(name);
    }
    
    // 09(1)
    public async Task<List<ClientOrderDto>> ObtenerClientesYPedidosSinTrackingAsync()
    {
        return await _unitOfWork.Clients.ObtenerClientesYPedidosSinTrackingAsync();
    }
    
    // 09(3)
    public async Task<List<ClienteTotalProductosDto>> ObtenerClientesConTotalProductosAsync()
    {
        return await _unitOfWork.Clients.ObtenerClientesConTotalProductosAsync();
    }
    
    
}