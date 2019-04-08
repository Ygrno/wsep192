using System;
using System.Collections.Generic;
using System.Text;
using BussinessLayer.Market;
using BussinessLayer.UsersManagment;


namespace ServiceLayer
{
    class System
    {
        private bool initialized = false;
        private List<Customer> customers;
        private bool signedin = false;
        private Guest global_guest;


        public System()
        {
            customers = new List<Customer>();
            createGuest();
        }

        public void register()
        {
            global_guest.register(customers, initialized);
            initialized = true;
        }

        public void createGuest()
        {
            this.global_guest = new Guest();
        }

        public void displayActions()
        {
            if (!signedin)
            {
                Console.WriteLine("Welcome Guest, what would you like to do today?");
                Console.WriteLine("Please enter the number of the requested action:");
                Console.WriteLine("1. log in\n 2. Search Products\n 3. add products to cart\n 4. watch and edit cart\n 5. buy products \n ");


            }

        }



    }
}
