using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class Guest
    {
        public void register(List<Customer> customers, bool initialized)
        {
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
            Customer customer;
            if (!initialized)
            {
                Admin admin = new Admin(user_name, pass);
                customer = new Customer(admin);
            }
            else
            {
                User user = new User(user_name, pass);
                customer = new Customer(user);
            }
            customers.Add(customer);
        }

        public void login()
        {

        }
    }
}
