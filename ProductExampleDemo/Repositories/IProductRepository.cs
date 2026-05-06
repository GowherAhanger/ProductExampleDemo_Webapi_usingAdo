using ProductExampleDemo.Models;

namespace ProductExampleDemo.Repositories;

public interface IProductRepository
{
        List<Product> GetAll();
        Product GetById(int id);  
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    
}