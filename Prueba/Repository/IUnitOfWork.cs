namespace Prueba.Repository;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    IOrderDetailRepository OrderDetails { get; }
    IOrderRepository Orders { get; }
    Task<int> SaveAsync();
}