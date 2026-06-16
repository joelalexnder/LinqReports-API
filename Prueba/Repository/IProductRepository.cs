using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Repository;

public interface IProductRepository
{
    //2
    Task<List<Product>> GetProductsByPriceGreaterThanAsync(decimal price);
    
    // 5
    Task<Product> ObtenerProductoMasCaroAsync();
    
    //7
    Task<decimal> CalcularPromedioPreciosAsync();
    //8
    Task<List<Product>> ObtenerProductosSinDescripcionAsync();
    
    
    
}