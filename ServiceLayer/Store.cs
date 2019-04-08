using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class Store
    {
        private List<Product> products;
        private BuyingPolicy buyingPolicy;
        private PurchasePolicy purchasePolicy;
        private SalesPolicy salesPolicy;
        private int storeID;
        private String name;
        private List<StoreOwner> storeOwners;

        public Store()
        {
            products = new List<Product>();
            buyingPolicy = new BuyingPolicy();
            purchasePolicy = new PurchasePolicy();
            salesPolicy = new SalesPolicy();
            storeOwners = new List<StoreOwner>();
        }

    }
}
