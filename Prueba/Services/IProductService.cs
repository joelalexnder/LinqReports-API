using Prueba.DTOs;
using Prueba.Models;

namespace Prueba.Services;

public interface IProductService
{
    //2
    Task<List<Product>> FilterProductsByPriceAsync(decimal price);
    
    //5
    Task<Product> ObtenerProductoMasCaroAsync();
    
    //7
    Task<decimal> CalcularPromedioPreciosAsync();
    
    //8
    Task<List<Product>> ObtenerProductosSinDescripcionAsync();
    
    
}
















