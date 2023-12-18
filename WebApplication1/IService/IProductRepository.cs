using WebApplication1.Model;

namespace WebApplication1.IService
{
    public interface IProductRepository
    {
        bool Add(Product model);
        List<Product> GetAll();
    }
}
