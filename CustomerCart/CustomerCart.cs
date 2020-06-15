using Cart.Model;
using System.Collections.Generic;

namespace Cart
{
    public class CustomerCart
    {
        private List<CustomerItem> _customeritems;
        public List<CustomerItem> CustomerItems => _customeritems;
        public CustomerCart()
        {
            _customeritems = new List<CustomerItem>();
        }


        public void AddToCart(Product product, int quantity)
        {
            CustomerItem customerItem = new CustomerItem();
            customerItem.Product = product;
            customerItem.Quantity = quantity;
            CustomerItems.Add(customerItem);
        }

        public decimal GetTotalCartAmount()
        {
            decimal netAmount = 0.0M;

            foreach (CustomerItem customerItem in _customeritems)
            {
                netAmount += (customerItem.GetProductTotal());
            }
            return netAmount;
        }


    }

}
