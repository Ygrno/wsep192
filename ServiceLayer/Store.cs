using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class Store
    {
        public List<Product> products;
        private BuyingPolicy buyingPolicy;
        private PurchasePolicy purchasePolicy;
        private SalesPolicy salesPolicy;
        private int storeID;
        public String name;
        public List<string> storeOwners;

        public Store(int storeId,string storeName, string storeOwnerName)
        {
            products = new List<Product>();
            buyingPolicy = new BuyingPolicy();
            purchasePolicy = new PurchasePolicy();
            salesPolicy = new SalesPolicy();
            storeOwners = new List<string>();
            storeOwners.Add(storeOwnerName);
            storeID = storeId;
            this.name = storeName;
        }

        public string getName()
        {
            return this.name;
        }

    }
}
