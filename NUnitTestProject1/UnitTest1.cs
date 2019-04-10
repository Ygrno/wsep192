using System.Collections.Generic;
using NUnit.Framework;
using ServiceLayer;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Initialize()//use case 1.1
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("", "123456"));
            Assert.AreEqual(sys.initialized, false);
            ServiceLayer.System.Reset();
            sys = (ServiceLayer.System.initialize("moti", "123456"));

            Assert.AreEqual(sys.initialized, true);

            ServiceLayer.System.Reset();
        }

        [Test]
        public void Register()//use case 2.2
        {
            

            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.initialized, true);

            Assert.AreEqual(sys.register("yael", "123456"), true);
            Assert.AreEqual(sys.register("yael", "123l56"), false);
            
            ServiceLayer.System.Reset();

        }

        [Test]
        public void login()//use case 2.3
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            //Assert.AreEqual(sys.register("yael", "123456"), true);
            Assert.AreEqual(sys.login("moti","123456"),true);
            ServiceLayer.System.Reset();
            sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.login("yael", "123456"), false);

            ServiceLayer.System.Reset();
        }

        [Test]
        public void search()//use case 2.5
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.login("moti", "123456"), true);
            Product milk = new Product("milk",12,"A");
            Product bread = new Product("bread", 24,"A");
            Store store = new Store(123,"walmart","");
            store.products.Add(milk);
            store.products.Add(bread);
            ServiceLayer.System.stores.Add(store);
            Assert.AreEqual(sys.searchProducts("milk"),true);
            Assert.AreEqual(sys.searchProducts("breaz"), false);

            ServiceLayer.System.Reset();
        }

        [Test]
        public void filter()//use case 2.5
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.login("moti", "123456"), true);
            Product milk = new Product("milk", 12,"A");
            Product milky = new Product("milky", 24, "A");
            milk.setCategory("Dairy");
            milky.setCategory("Dairy");
            Store store = new Store(123, "walmart", "");
            store.products.Add(milk);
            store.products.Add(milky);
            ServiceLayer.System.stores.Add(store);
            Assert.AreEqual(sys.filterProducts("Dairy"), true);
            Assert.AreEqual(sys.filterProducts("meat"), false);

            ServiceLayer.System.Reset();
        }


        [Test]
        public void saveProducts()//use case 2.6
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            List<Product> chosenProducts = new List<Product>();
            Product milk = new Product("milk", 12, "A");
            Product bread = new Product("bread", 24, "A");
            Product eggs = new Product("eggs", 1, "A");
            Product cigar = new Product("cigar", 100, "A");
            chosenProducts.Add(milk);
            chosenProducts.Add(bread);
            chosenProducts.Add(eggs);
            chosenProducts.Add(cigar);
            Assert.AreEqual(sys.saveProductToCart("", chosenProducts),true);

            List<Product> emptyProductsList = new List<Product>();
            Assert.AreEqual(sys.saveProductToCart("", emptyProductsList), false);


            Assert.AreEqual(sys.saveProductToCart("moti", chosenProducts), false);

            Assert.AreEqual(sys.login("moti", "123456"), true);
            Assert.AreEqual(sys.saveProductToCart("moti", chosenProducts), true);
            Assert.AreEqual(sys.saveProductToCart("moti", emptyProductsList), false);

            ServiceLayer.System.Reset();

        }

        [Test]
        public void watchAndEditCart()//use case 2.7
        {
            //Watch Cart
            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.watchCart("moti"),true);

            //Edit Cart

            //Saving products to moti's cart
            Assert.AreEqual(sys.login("moti", "123456"), true);
            Product eggs = new Product("eggs", 1, "A");
            Product cigar = new Product("cigar", 100, "A");
            List<Product> products = new List<Product>();
            products.Add(eggs);
            products.Add(cigar);
            sys.saveProductToCart("moti", products);

            
            List<Product> toRemove = new List<Product>();
            Assert.AreEqual(sys.editCart("moti", toRemove),true);

            ServiceLayer.System.Reset();

        }

        [Test]
        public void BuyingProcess()//use case 2.8
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.login("moti", "123456"), true);
            List<Product> products = new List<Product>();
            Store A = new Store(1, "A", "default");
            Store B = new Store(2, "B", "default");
            ServiceLayer.System.stores.Add(A);
            ServiceLayer.System.stores.Add(B);
            Product eggs = new Product("eggs", 1, "A");
            Product cigar = new Product("cigar", 100, "B");
            A.products.Add(eggs);
            B.products.Add(cigar);
            products.Add(eggs);
            products.Add(cigar);
            sys.saveProductToCart("moti", products);

            Assert.AreEqual(sys.buyProductsInCart(sys.getCart("moti")), true);
            Product apple = new Product("apple", 4, "B");
            products.Clear();
            products.Add(apple);
            sys.saveProductToCart("moti", products);
            Assert.AreEqual(sys.buyProductsInCart(sys.getCart("moti")), false);

        }



    }
}