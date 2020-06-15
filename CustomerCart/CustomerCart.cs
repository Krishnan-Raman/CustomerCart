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


    }

}
