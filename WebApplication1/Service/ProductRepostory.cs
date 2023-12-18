using WebApplication1.IService;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ProductRepostory : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepostory(DatabaseContext context)
        {
            this._context = context;
        }
        public bool Add(Product model)
        {
            try
            {
                _context.Product.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }
    }
}
