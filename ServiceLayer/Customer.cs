using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ServiceLayer
{
    public class Customer
    {
        private Cart cart;
        private User currentState;
        public bool loggedin = false;

        public bool register(string userName, string password)
        {
            System sys = System.getInstance();
            if (sys == null) return false;
            else
            {
                sys.register(userName,password);
                return true;
            }


        }

        public Customer(User state)
        {
            cart = new Cart();
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

        public Cart getCart()
        {
            return this.cart;
        }

        public void setGuestState()
        {
            currentState = null;
        }



    }
}
