namespace SportStore.Models;

public class StoreRepository : IStoreRepository
{
    private StoreDbContext _context;

    public StoreRepository(StoreDbContext context) // Corrected constructor
    {
        _context = context;
    }

    IQueryable<Product> IStoreRepository.GetProducts => _context.Products;
}