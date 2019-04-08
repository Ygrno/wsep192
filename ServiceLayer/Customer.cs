using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class Customer
    {
        private List<Cart> carts;
        private User currentState;

        public Customer(User state)
        {
            carts = new List<Cart>();
            this.currentState = state;
        }

        public void searchProduct()
        {
            

        }

        public void filterResult()
        {

        }

        public void displayCart()
        {

        }

        public void editCart()
        {

        }

        public void Pay()
        {

        }

        public User getCurrentState()
        {
            return this.currentState;
        }



    }
}
