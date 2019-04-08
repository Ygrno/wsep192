using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class StoreOwner : User
    {
        private int storeID;

        public StoreOwner(string user_name, string password) : base(user_name, password)
        {
        }

        public void setStore(int storeID)
        {
            this.storeID = storeID;
        }

        public int getStore()
        {
            return this.storeID;
        }

        public void addProduct()
        {

        }

        public void deleteProduct()
        {

        }

        public void editProduct()
        {

        }

        public void addStoreOwner()
        {

        }

        public void addStoreManager()
        {

        }

        public void removeStoreOwner()
        {

        }

    }
}
