using Microsoft.EntityFrameworkCore;
using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Repository.Implements;

public class OrderRepository : IOrderRepository
{
    private readonly LinqexampleContext _context;

    public OrderRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> ObtenerPedidosDespuesDeFechaAsync(DateTime fecha)
    {
        //6
        return await _context.Orders
            .Where(o => o.OrderDate > fecha)
            .ToListAsync();
    }
    
    //9
    public async Task<ClienteMasPedidosDto?> ObtenerClienteConMasPedidosAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.ClientId)
            .Select(grupo => new ClienteMasPedidosDto
            {
                ClientId = grupo.Key,
                TotalPedidos = grupo.Count()
            })
            .OrderByDescending(c => c.TotalPedidos)
            .FirstOrDefaultAsync();
    }
    //11
    public async Task<List<string>> ObtenerNombresProductosPorClienteAsync(int clientId)
    {
        return await _context.OrderDetails
            .Where(od => od.Order.ClientId == clientId) 
            .Select(od => od.Product.Name)
            .Distinct() 
            .ToListAsync();
    }
    //09(2)
    public async Task<List<OrderDetailsDto>> ObtenerPedidosConDetallesYProductosAsync()
    {
        return await _context.Orders
            .Include(order => order.OrderDetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking() 
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Products = order.OrderDetails.Select(od => new ProductDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity,
                    Price = od.Product.Price
                }).ToList()
            })
            .ToListAsync(); 
    }
    
    // 09(4)
    public async Task<List<SalesByClientDto>> ObtenerVentasPorClienteAsync(int id)
    {
        return await _context.Orders
            .Where(order => order.ClientId == id)
            .Include(order => order.OrderDetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking()
            .GroupBy(order => order.ClientId)
            .Select(group => new SalesByClientDto
            {
                ClientName = _context.Clients
                    .FirstOrDefault(c => c.ClientId == group.Key)!.Name,
                
                TotalSales = group.Sum(order => order.OrderDetails
                    .Sum(detail => detail.Quantity * detail.Product.Price))
            })
            .OrderByDescending(s => s.TotalSales) 
            .ToListAsync();
    }
}