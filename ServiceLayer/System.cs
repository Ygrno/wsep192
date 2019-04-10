using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BussinessLayer.Market;
using BussinessLayer.UsersManagment;


namespace ServiceLayer
{
    public class System
    {
        private static System sys;
        public bool initialized = false;
        private List<Customer> customers;
        // public bool signedin = false;
        public static List<Store> stores;
        private Customer global_guest;
        private int storeId = 10000;



        private System(string userName, string password)
        {
            customers = new List<Customer>();
            stores = new List<Store>();
            createGuest();
            Console.WriteLine("Connecting to External systems ...");
            connectExternalSystems();
            Console.WriteLine("Welcome to the Market System!");
            Console.WriteLine("In order to use the system for the first time, an admin must be created.");

            if(this.register(userName, password))
                initialized = true;
        }

        private void connectExternalSystems()
        {
            Console.WriteLine("Connection to external systems succeeded!");
        }

        public static System initialize(string userName, string password)
        {
            if (sys == null) sys = new System(userName, password);
            
            return sys;
        }
        public static System getInstance()
        {
            return sys;
        }

        public bool register(string userName, string password)
        {
            /*
Console.WriteLine("Please enter a user name:");
String user_name = Console.ReadLine();
foreach (Customer c in customers)
{
    User u = c.getCurrentState();
    if (u != null && u.getName().Equals(user_name))
    {
        Console.WriteLine("The user name is already taken, please try again");
        return;
    }
}
Console.WriteLine("Please enter a Password:");
String pass = Console.ReadLine();
*/
            
            try
            {
                if (userName == null || password == null || userName.Equals("") || password.Equals(""))
                {
                    throw new Exception("invalid user name or password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }

            foreach (Customer c in customers)
            {
                User u = c.getCurrentState();
                if (u != null && u.getUserName().Equals(userName))
                {
                    Console.WriteLine("The user name is already taken, please try again");
                    return false;
                }
            }

            Customer customer;
            if (!initialized)
            {
                Admin admin = new Admin(userName, password);
                customer = new Customer(admin);
            }
            else
            {
                User user = new User(userName, password);
                customer = new Customer(user);
            }
            customers.Add(customer);
            return true;
            /*
            if (global_guest.register(customers, initialized, userName, password))
            {
                initialized = true;
                return true;
            }
            return false;*/
        }



        public Customer createGuest()
        {
            global_guest = new Customer(null);
            return global_guest;

        }

        public bool logout(string username)
        {
            foreach (Customer c in customers)
            {
                User u = c.getCurrentState();
                if (u!=null && c.getCurrentState().getUserName().Equals(username))
                {
                    if (!(c.loggedin))
                    {
                        return false;
                    }

                    c.loggedin = false;
                    c.setGuestState();
                    return true;
                }
            }

            return false;
        }

        public bool openStore(string storename, string userName)
        {
            foreach (var sto in stores)
            {
                if (sto.getName().Equals(storename))
                {
                    return false;
                }
            }

            foreach (var cos in customers)
            {
                User u = cos.getCurrentState();
                if (u!=null && cos.getCurrentState().getUserName().Equals(userName))
                {
                    Interlocked.Increment(ref storeId);
                    stores.Add(new Store(storeId, storename, (userName)));
                    return true;
                }
            }

            return false;
        }

        public bool saveProductToCart(string userName, List<Product> products)
        {
            if (products.Count == 0) return false;

            if (userName.Equals(""))
            {
                global_guest.getCart().getProducts().AddRange(products);
                return true;

            }


            foreach (Customer c in customers)
            {
                User u = c.getCurrentState();
                if (u != null && u.getUserName().Equals(userName) && c.loggedin)
                {
                    c.getCart().getProducts().AddRange(products);
                    return true;
                }

            }

            return false;

        }

        public bool watchCart(string userName)
        {
            List<Product> cart;
            foreach (Customer c in customers)
            {
                User u = c.getCurrentState();
                if (u != null && u.getUserName().Equals(userName) && c.loggedin)
                {
                    cart = c.getCart().getProducts();
                    foreach (Product p in cart)
                    {
                        Console.WriteLine("product name:" + p.name + ". price:" + p.price + ". store:" + p.storeName);
                        return true;
                    }
                }
            }
            
            cart = global_guest.getCart().getProducts();
            foreach (Product p in cart)
            {
                Console.WriteLine("product name:" + p.name + ". price:" + p.price + ". store:" + p.storeName);
            }
            return true;
        }

        public bool editCart(string userName,List<Product> toRemove)
        {
            
            List<Product> cart = null;
            foreach (Customer c in customers)
            {
                User u = c.getCurrentState();
                if (u != null && u.getUserName().Equals(userName) && c.loggedin)
                {
                    cart = c.getCart().getProducts();
                }
            }

            if (cart != null)
            {
                foreach (Product p in toRemove)
                {
                    if (cart.Contains(p)) cart.Remove(p);
                }

                return true;
            }

            cart = global_guest.getCart().getProducts();
            foreach (Product p in toRemove)
            {
                if (cart.Contains(p)) cart.Remove(p);
            }
            return true;

        }

        public Cart getCart(string userName)
        {
            foreach (Customer c in customers)
            {
                User u = c.getCurrentState();
                if (u != null && c.loggedin && u.getUserName().Equals(userName))
                {
                    return c.getCart();
                }

            }

            return global_guest.getCart();
        }



        public bool login(string userName, string password)
        {
            foreach (Customer c in customers)
            {
                User user = c.getCurrentState();
                if (user != null && user.getUserName().Equals(userName) && user.getPassword().Equals(password))
                {
                    if (c.loggedin) return false;
                    else c.loggedin = true;
                    return true;
                }
            }
         
            return false;
        }

        public bool searchProducts(string input)
        {

            foreach (Store st in stores)
            {
                foreach (Product product in st.products)
                {
                    if (product.name.Equals(input))
                    {
                        Console.WriteLine("product name:" + product.name + ". price:" + product.price + ". store:"+st.name);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool filterProducts(string input)
        {
            bool found = false;

            foreach (Store st in stores)
            {
                foreach (Product product in st.products)
                {
                    if (product.getCategory().Equals(input))
                    {
                        found = true;
                        Console.WriteLine("product name:" + product.name + ". price:" + product.price + ". store:" + st.name);
                    }
                }
            }

            return found;
        }

        public static void Reset()
        {
            sys = null;
        }

        public bool addMangerToStore(string storename, string username)
        {
            foreach (var sto in stores)
            {
                if (sto.getName().Equals(storename))
                {
                    sto.storeOwners.Add(username);
                    return true;
                }
            }
            return false;
        }

        public bool checkAvailabilityOfProduct(Product P, Store S)
        {
            if (S.products.Contains(P)) return true;

            return false;
        }

        public bool buyingPolicyCheck(Product P, Store S)
        {
            //Given in the requirements 
            return true;


        }

        public int discountPolicyCheck(Product P, Store S)
        {

            return P.price;


        }

        public bool buyProductsInCart(Cart C)
        {

            foreach (Product p in C.getProducts())
            {
                Store s = this.searchStore(p.storeName);
                if (s != null && checkAvailabilityOfProduct(p, s) && buyingPolicyCheck(p, s))
                {
                    p.price = discountPolicyCheck(p, s);

                }
                else return false;

            }

            return true;

        }

        private Store searchStore(string storeName)
        {
            foreach (Store store in stores)
            {
                if (store.getName().Equals(storeName))
                {
                    return store;
                }

            }

            return null;
        }



    }
}
