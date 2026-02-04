using SimpleStore.DAL;
using SimpleStore.Models;

namespace SimpleStore.BLL;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public List<Product> GetProducts()
        => _repo.GetAll();

    public void Create(Product product)
    {
        if (product.Name.Contains("price", StringComparison.OrdinalIgnoreCase))
            throw new Exception("Product name cannot contain 'price'");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        _repo.Add(product);
    }

    public int GetTotalCount()
        => _repo.GetTotalCount();

    public void Delete(int id)
    {
        _repo.Delete(id);
    }

    public Product GetById(int id)
    {
        return _repo.GetById(id);
    }

    public void Update(Product product)
    {
        if (product.Name.Contains("price", StringComparison.OrdinalIgnoreCase))
            throw new Exception("Product name cannot contain 'price'");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");
        _repo.Update(product);
    }
}