using Cart;
using Cart.Model;
using Cart.PromotionTypes;
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
            decimal totalCartAmount=0.0M, totalPromotionDiscount =0.0M;
            AddProduct();
            AddPromotionTypes();
            AddScenarioAProductToCart();
            PromotionEngine promotionEngine = new PromotionEngine(_promotionTypes);
            totalCartAmount = _customerCart.GetTotalCartAmount();
            totalPromotionDiscount = promotionEngine.GetPromotionDiscount(_customerCart.CustomerItems);
            Assert.AreEqual(100, totalCartAmount - totalPromotionDiscount);
        }

        [TestMethod]
        public void ScenarioBTest()
        {
            decimal totalCartAmount = 0.0M, totalPromotionDiscount = 0.0M;
            AddProduct();
            AddPromotionTypes();
            AddScenarioBProductToCart();

            PromotionEngine promotionEngine = new PromotionEngine(_promotionTypes);
            totalCartAmount = _customerCart.GetTotalCartAmount();
            totalPromotionDiscount = promotionEngine.GetPromotionDiscount(_customerCart.CustomerItems);
            Assert.AreEqual(370, totalCartAmount - totalPromotionDiscount);
        }

        [TestMethod]
        public void ScenarioCTest()
        {
            decimal totalCartAmount = 0.0M, totalPromotionDiscount = 0.0M;
            AddProduct();
            AddPromotionTypes();
            AddScenarioCProductToCart();
            PromotionEngine promotionEngine = new PromotionEngine(_promotionTypes);
            totalCartAmount = _customerCart.GetTotalCartAmount();
            totalPromotionDiscount = promotionEngine.GetPromotionDiscount(_customerCart.CustomerItems);
            Assert.AreEqual(280, totalCartAmount - totalPromotionDiscount);
        }

        private void AddScenarioCProductToCart()
        {
            Product firstProduct = _productRepository.GetProduct(FirstProductName);
            Product secondProduct = _productRepository.GetProduct(SecondProductName);
            Product thirdProduct = _productRepository.GetProduct(ThirdProductName);
            Product fourthProduct = _productRepository.GetProduct(FourthProductName);

            _customerCart = new CustomerCart();
            _customerCart.AddToCart(firstProduct, 3);
            _customerCart.AddToCart(secondProduct, 5);
            _customerCart.AddToCart(thirdProduct, 1);
            _customerCart.AddToCart(fourthProduct, 1);
        }

        private void AddScenarioBProductToCart()
        {
            Product firstProduct = _productRepository.GetProduct(FirstProductName);
            Product secondProduct = _productRepository.GetProduct(SecondProductName);
            Product thirdProduct = _productRepository.GetProduct(ThirdProductName);

            _customerCart = new CustomerCart();
            _customerCart.AddToCart(firstProduct, 5);
            _customerCart.AddToCart(secondProduct, 5);
            _customerCart.AddToCart(thirdProduct, 1);
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
            _promotionTypes.Add(new SingleSKUPromotionType(FirstProductName, 3, 130));
            _promotionTypes.Add(new SingleSKUPromotionType(SecondProductName, 2, 45));
            _promotionTypes.Add(new TwoSKUPromotionType(_productRepository.GetProduct(ThirdProductName), _productRepository.GetProduct(FourthProductName), 30));


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
