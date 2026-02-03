using SimpleStore.Data;
using SimpleStore.Models;
using Microsoft.Data.SqlClient;

namespace SimpleStore.DAL;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public ProductRepository(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public List<Product> GetAll()
        => _context.Products.ToList();

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _context.Products.Find(id);
        if(product == null) return;

        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public int GetTotalCount()
    {
        using SqlConnection con = new SqlConnection(
            _config.GetConnectionString("DefaultConnection"));

        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products", con);
        con.Open();
        return (int)cmd.ExecuteScalar();
    }

    public Product GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
}