using Microsoft.EntityFrameworkCore;
using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Repository.Implements;

public class ClientRepository : IClientRepository
{
    private readonly LinqexampleContext _context;

    public ClientRepository(LinqexampleContext context)
    {
        _context = context;
    }
    public async Task<List<Client>> ObtenerClientesPorNombreAsync(string name)
    {
        // ejerc 1
        return await _context.Clients
            .Where(c => c.Name.StartsWith(name))
            .ToListAsync();
    }
    // 09(1)
    public async Task<List<ClientOrderDto>> ObtenerClientesYPedidosSinTrackingAsync()
    {
        return await _context.Clients
            .AsNoTracking() 
            .Select(client => new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = client.Orders.Select(order => new OrderDto
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate
                }).ToList()
            })
            .ToListAsync(); 
    }
    
    //09(3)
    public async Task<List<ClienteTotalProductosDto>> ObtenerClientesConTotalProductosAsync()
    {
        return await _context.Clients
            .AsNoTracking()
            .Select(client => new ClienteTotalProductosDto
            {
                ClientName = client.Name,
                TotalProducts = client.Orders.Sum(order => 
                    order.OrderDetails.Sum(detail => detail.Quantity)) 
            })
            .ToListAsync();
    }
}