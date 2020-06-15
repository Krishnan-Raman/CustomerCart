using Cart.Model;
using System.Collections.Generic;

namespace Cart
{
    public interface IPromotionTypes
    {
        decimal GetDiscount(List<CustomerItem> customerItems);

    }

    public class SingleSKUPromotionType : IPromotionTypes

    {
       
        public decimal GetDiscount(List<CustomerItem> customerItems)
        {
            decimal promotionDiscount = 0.0M;

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
