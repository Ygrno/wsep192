using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class Start
    {
        static void Main(string[] args)
        {

            //This is a start of UI example. we don't need this in version 1.

            System system = new System();
            Console.WriteLine("Welcome to the Market System!");
            Console.WriteLine("In order to use the system for the first time, an admin must be created.");
            system.register();
            system.displayActions();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;

            }


            Console.ReadLine();
        }
    }
}
