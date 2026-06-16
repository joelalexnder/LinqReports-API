using Prueba.DTOs;
using Prueba.Models;
using Prueba.Repository;

namespace Prueba.Services.Implements;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //2
    public async Task<List<Product>> FilterProductsByPriceAsync(decimal price)
    {
        return await _unitOfWork.Products.GetProductsByPriceGreaterThanAsync(price);
    }
    //5
    public async Task<Product> ObtenerProductoMasCaroAsync()
    {
        return await _unitOfWork.Products.ObtenerProductoMasCaroAsync();
    }
    
    //7
    public async Task<decimal> CalcularPromedioPreciosAsync()
    {
        return await _unitOfWork.Products.CalcularPromedioPreciosAsync();
    }
    
    //8
    public async Task<List<Product>> ObtenerProductosSinDescripcionAsync()
    {
        return await _unitOfWork.Products.ObtenerProductosSinDescripcionAsync();
    }
    //10
    public async Task<List<PedidoCompletoDto>> ObtenerTodosLosPedidosConDetallesAsync()
    {
        return await _unitOfWork.OrderDetails.ObtenerTodosLosPedidosConDetallesAsync();
    }
    
    
    
    
    
    
    
    
    
    
    
}
