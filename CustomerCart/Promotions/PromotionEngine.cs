
using Cart.Model;
using System.Collections.Generic;

namespace Cart
{
    public class PromotionEngine
    {
        private List<IPromotionTypes> _promotionTypes;

        public PromotionEngine(List<IPromotionTypes> promotionTypes)
        {
            _promotionTypes = new List<IPromotionTypes>();
            _promotionTypes.AddRange(promotionTypes);
        }

        public decimal GetNetTotal(List<CustomerItem> customerItems)
        {
            decimal promotionDiscount = 0.0M;
            var totalAmount = GetTotalAmount(customerItems);
            foreach (var promotiontype in _promotionTypes)
            {
                promotionDiscount += promotiontype.GetDiscount(customerItems);
            }

            return totalAmount - promotionDiscount;
        }

        public decimal GetTotalAmount(List<CustomerItem> customerItems)
        {
            decimal netAmount = 0.0M;

            foreach (CustomerItem customerItem in customerItems)
            {
                netAmount += (customerItem.GetTotalAmount());
            }
            return netAmount;
        }
    }
}
