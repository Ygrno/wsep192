using System.Security.Cryptography;
using NUnit.Framework;
using ServiceLayer;
using System = ServiceLayer.System;

namespace Tests
{
    public class Tests5
    {
        //Use case 5.1
        [Test]
        public void storeManagerTriesToMakeACommand()
        {
            ServiceLayer.System s1 = ServiceLayer.System.initialize("Admin", "password123");
            s1.register("Nati", "123456");
            s1.register("Ben", "123");

            s1.login("Nati", "123456");
            s1.openStore("storename", "Nati");
            s1.addMangerToStore("storename", "Ben");

            //TODO add a command for the new manager(Ben) to do

            s1.logout("Nati");

        }
    }
}
