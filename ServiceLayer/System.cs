using System;
using System.Collections.Generic;
using System.Text;
using BussinessLayer.Market;
using BussinessLayer.UsersManagment;


namespace ServiceLayer
{
    public class System
    {
        private static System sys;
        public bool initialized = false;
        private List<Costumer> costumers;
        private bool signedin = false;
        private Guest global_guest;


        private System(string userName, string password)
        {
            costumers = new List<Costumer>();
            createGuest();
            Console.WriteLine("Connecting to External systems ...");
            connectExternalSystems();
            Console.WriteLine("Welcome to the Market System!");
            Console.WriteLine("In order to use the system for the first time, an admin must be created.");
            this.register(userName, password);

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

        public bool register(string userName, string password)
        {
            if (global_guest.register(costumers, initialized, userName, password))
            {
                initialized = true;
                return true;
            }

            return false;
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

        public static void Reset()
        {
            sys = null;
        }



    }
}
