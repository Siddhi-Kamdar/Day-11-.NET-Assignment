using SimpleStore.Models;

namespace SimpleStore.BLL;

public interface IProductService
{
    List<Product> GetProducts();
    void Create(Product product);
    int GetTotalCount();
    void Delete(int id);

    Product GetById(int id);
    void Update(Product product);
}