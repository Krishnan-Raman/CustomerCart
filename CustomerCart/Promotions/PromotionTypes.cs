using Cart.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cart
{
    public interface IPromotionTypes
    {
        decimal GetDiscount(List<CustomerItem> customerItems);

    }

    

    

}
