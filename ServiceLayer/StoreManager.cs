using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class StoreManager : StoreOwner
    {
        private bool[] privileges;
        public StoreManager(string user_name, string password, bool[] privileges) : base(user_name, password)
        {
            this.privileges = privileges;
        }

        public override bool addStore(Store store)
        {
            if (privileges[0])
            {
                return base.addStore(store);
            }
            return false;
        }

        public override bool addProduct(Product p, Store store)
        {
            if (privileges[1])
            {
                return base.addProduct(p, store);
            }
            return false;
        }

        public override bool deleteProduct(Product p, Store store)
        {
            if (privileges[2])
            {
                return base.deleteProduct(p, store);
            }
            return false;
        }

        public override bool editProduct(Product p, Store store, Product newProd)
        {
            if (privileges[3])
            {
                return base.editProduct(p, store, newProd);
            }
            return false;
        }

        public override bool addStoreOwner(Store store, string customerName)
        {
            if (privileges[4])
            {
                return base.addStoreOwner(store, customerName);
            }
            return false;
        }

        public override bool addStoreManager(Store store, string customerName)
        {
            if (privileges[5])
            {
                return base.addStoreManager(store, customerName);
            }
            return false;
        }

        public override bool removeStoreOwner(Store store, string customerName)
        {
            if (privileges[6])
            {
                return base.removeStoreOwner(store, customerName);
            }
            return false;
        }


    }
}
