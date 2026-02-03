using SimpleStore.Models;

namespace SimpleStore.DAL;

public interface IProductRepository
{
    List<Product> GetAll();
    void Add(Product product);
    int GetTotalCount();

    void Delete(int id);

    Product GetById(int id);
    void Update(Product product);
}