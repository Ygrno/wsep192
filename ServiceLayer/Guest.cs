using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class Guest
    {
        public bool register(List<Customer> costumers, bool initialized, string userName, string password)
        {
            /*
            Console.WriteLine("Please enter a user name:");
            String user_name = Console.ReadLine();
            foreach (Customer c in costumers)
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
            Customer customer;

            foreach (Customer c in costumers)
            {
                User u = c.getCurrentState();
                if (u != null && u.getUserName().Equals(userName))
                {
                    Console.WriteLine("The user name is already taken, please try again");
                    return false;
                }
            }

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
            costumers.Add(customer);
            return true;
        }


    }
}
