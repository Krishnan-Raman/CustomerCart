using Cart.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cart
{
    public class ProductRepository
    {
        private List<Product> _products;

        public List<Product> Products => _products;
        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public Product GetProduct(string productName)
        {
            return _products.Where(x => x.Name == productName).Select(x => x).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }

}
