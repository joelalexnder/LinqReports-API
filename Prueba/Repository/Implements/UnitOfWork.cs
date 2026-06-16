using Prueba.Models;

namespace Prueba.Repository.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly LinqexampleContext _context;
    public IClientRepository Clients { get; private set; }
    public IProductRepository Products { get; private set; }
    public IOrderDetailRepository OrderDetails { get; private set; }
    public IOrderRepository Orders { get; private set; }

    public UnitOfWork(LinqexampleContext context)
    {
        _context = context;
        Clients = new ClientRepository(_context);
        Products = new ProductRepository(_context);
        OrderDetails = new OrderDetailRepository(_context);
        Orders = new OrderRepository(_context);
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}