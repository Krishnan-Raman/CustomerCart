using Cart;
using Cart.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cart.PromotionTypes
{
    public class TwoSKUPromotionType : IPromotionTypes

    {
        public Product FirstProduct { get; }
        public Product SeconProduct { get; }
        public decimal PromotionAmount { get; }


        public TwoSKUPromotionType(Product firstProduct, Product secondProduct, decimal promotionAmount)
        {
            FirstProduct = firstProduct;
            SeconProduct = secondProduct;
            PromotionAmount = promotionAmount;
        }

        public decimal GetDiscount(List<CustomerItem> customerItems)
        {
            decimal promotionDiscount = 0.0M, productAmountDifference = 0.0M;
            int firstProductcount = 0, secondProductcount = 0;

            productAmountDifference = FirstProduct.Price + SeconProduct.Price - PromotionAmount;
            CustomerItem firstproductItem = customerItems.Where(x => (x.Product.Name == FirstProduct.Name)).FirstOrDefault();
            if (firstproductItem == null)
            {
                return promotionDiscount;
            }
            firstProductcount = firstproductItem.Quantity;
            CustomerItem secondProductItem = customerItems.Where(x => (x.Product.Name == SeconProduct.Name)).FirstOrDefault();
            if (secondProductItem == null)
            {
                return promotionDiscount;
            }
            secondProductcount = secondProductItem.Quantity;

            promotionDiscount = Math.Min(firstProductcount, secondProductcount) * productAmountDifference;

            return promotionDiscount;
        }
    }
}
