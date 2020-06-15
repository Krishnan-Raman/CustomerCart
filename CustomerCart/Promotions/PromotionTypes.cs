using Cart.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cart
{
    public interface IPromotionTypes
    {
        decimal GetDiscount(List<CustomerItem> customerItems);

    }

    public class SingleSKUPromotionType : IPromotionTypes

    {

        public string ProductName { get; }
        public int Quantity { get; }
        public decimal PromotionAmount { get; }
        public SingleSKUPromotionType(string productName, int quantity, decimal promotionAmount)
        {
            ProductName = productName;
            Quantity = quantity;
            PromotionAmount = promotionAmount;
        }
        public decimal GetDiscount(List<CustomerItem> customerItems)
        {
            decimal totalAmount = 0.0M, promotionAmount = 0.0M, promotionDiscount = 0.0M;

            CustomerItem productItem = customerItems.Where(x => x.Product.Name == ProductName).FirstOrDefault();
            if (productItem.Product.Name == ProductName && productItem.Quantity >= Quantity)
            {
                totalAmount += productItem.Quantity * productItem.Product.Price;
                promotionAmount += ((int)(productItem.Quantity / Quantity) * PromotionAmount) + (productItem.Quantity % Quantity) * productItem.Product.Price;
            }

            promotionDiscount = totalAmount - promotionAmount;
            return promotionDiscount;
        }
    }

    public class TwoSKUPromotionType : IPromotionTypes

    {

        public decimal GetDiscount(List<CustomerItem> customerItems)
        {
            decimal promotionDiscount = 0.0M;


            return promotionDiscount;
        }
    }

}
