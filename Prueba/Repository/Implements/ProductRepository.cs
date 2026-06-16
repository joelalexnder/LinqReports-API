using Microsoft.EntityFrameworkCore;
using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Repository.Implements;

public class ProductRepository : IProductRepository
{
    private readonly LinqexampleContext _context;
    public ProductRepository(LinqexampleContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsByPriceGreaterThanAsync(decimal price)
    {
        // ejer 2
        return await _context.Products
            .Where(p => p.Price > price)
            .ToListAsync();
    }

    public async Task<Product?> ObtenerProductoMasCaroAsync()
    {
        //5
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }
    
    public async Task<decimal> CalcularPromedioPreciosAsync()
    {
        //7
        return await _context.Products
            .Select(p => p.Price) 
            .AverageAsync();    
    }
    
    public async Task<List<Product>> ObtenerProductosSinDescripcionAsync()
    {
        //8
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }
    
    
    
    
}