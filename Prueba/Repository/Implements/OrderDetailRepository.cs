using Microsoft.EntityFrameworkCore;
using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Repository.Implements;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly LinqexampleContext _context;

    public OrderDetailRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public async Task<List<DetalleProductoDto>> ObtenerDetallePorOrdenAsync(int ordenId)
    {
        // ejer 3
        return await _context.OrderDetails
            .Where(od => od.OrderId == ordenId)
            .Select(od => new DetalleProductoDto
            {
               
                NombreProducto = od.Product.Name, 
                Cantidad = od.Quantity
            })
            .ToListAsync();
    }
    
    public async Task<int> CalcularTotalProductosPorOrdenAsync(int ordenId)
    {
        // ejer 4
        return await _context.OrderDetails
            .Where(od => od.OrderId == ordenId)
            .Select(od => od.Quantity)
            .SumAsync(); 
    }
    
    //10
    public async Task<List<PedidoCompletoDto>> ObtenerTodosLosPedidosConDetallesAsync()
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId > 0) 
            .Select(od => new PedidoCompletoDto
            {
                OrderId = od.OrderId,
                NombreProducto = od.Product.Name,
                Cantidad = od.Quantity
            })
            .ToListAsync();
    }
    
    //12
    public async Task<List<string>> ObtenerNombresClientesPorProductoAsync(int productoId)
    {
        return await _context.OrderDetails
            .Where(od => od.ProductId == productoId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
}