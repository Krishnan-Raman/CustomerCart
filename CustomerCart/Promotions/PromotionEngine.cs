
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

        public decimal GetPromotionDiscount(List<CustomerItem> customerItems)
        {
            decimal promotionDiscount = 0.0M;
            foreach (var promotiontype in _promotionTypes)
            {
                promotionDiscount += promotiontype.GetDiscount(customerItems);
            }
            return promotionDiscount;
        }

        
    }
}
