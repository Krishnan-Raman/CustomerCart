using Cart.Model;

namespace Cart.Model
{
    public class CustomerItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal GetTotalAmount()
        {
            if (Product != null)
            {
                return Product.Price * Quantity;
            }
            return 0.0M;
        }
    }
}
