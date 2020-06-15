﻿using Cart;
using Cart.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CustomerCartTest
{
    [TestClass]
    public class CustomerCartTest
    {
        private const string FirstProductName = "A";
        private const string SecondProductName = "B";
        private const string ThirdProductName = "C";
        private const string FourthProductName = "D";
        ProductRepository _productRepository;
        List<IPromotionTypes> _promotionTypes;
        CustomerCart _customerCart;
        [TestMethod]
        public void ScenarioATest()
        {
            decimal netTotal = 0.0M;
            AddProduct();
            AddPromotionTypes();
            AddScenarioAProductToCart();
            PromotionEngine promotionEngine = new PromotionEngine(_promotionTypes);
            netTotal = promotionEngine.GetNetTotal(_customerCart.CustomerItems);
            Assert.AreEqual(100, netTotal);
        }

        private void AddProduct()
        {
            _productRepository = new ProductRepository();
            _productRepository.AddProduct(new Product(FirstProductName, 50));
            _productRepository.AddProduct(new Product(SecondProductName, 30));
            _productRepository.AddProduct(new Product(ThirdProductName, 20));
            _productRepository.AddProduct(new Product(FourthProductName, 15));
        }

        private void AddPromotionTypes()
        {
            _promotionTypes = new List<IPromotionTypes>();
            
        }

        private void AddScenarioAProductToCart()
        {
            Product firstProduct = _productRepository.GetProduct(FirstProductName);
            Product secondProduct = _productRepository.GetProduct(SecondProductName);
            Product thirdProduct = _productRepository.GetProduct(ThirdProductName);

            _customerCart = new CustomerCart();
            _customerCart.AddToCart(firstProduct, 1);
            _customerCart.AddToCart(secondProduct, 1);
            _customerCart.AddToCart(thirdProduct, 1);
        }
    }
}