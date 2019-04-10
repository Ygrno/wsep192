using NUnit.Framework;
using ServiceLayer;
using System = ServiceLayer.System;

namespace Tests
{
    public class Tests3
    {
        //Use case 3.1
        [Test]
        public void logOut()
        {
            ServiceLayer.System s1 = ServiceLayer.System.initialize("Admin", "password123");
            s1.register("Nati", "123456");
            s1.login("Nati", "123456");


            bool ans = s1.logout("Nati");
            Assert.AreEqual(ans, true);
            bool ans2 = s1.logout("Nati");
            Assert.AreEqual(ans2, false);


            ServiceLayer.System.Reset();
        }

        //Use case 3.2
        [Test]
        public void openStore()
        {
            ServiceLayer.System s1 = ServiceLayer.System.initialize("Admin", "password123");
            s1.register("Nati", "123456");
            s1.login("Nati", "123456");
            bool ans = s1.openStore("storeName", "Nati");
            Assert.AreEqual(ans, true);

            //If the name of the store is already exist
            bool ans2 = s1.openStore("storeName", "Nati");
            Assert.AreEqual(ans2, false);

            //If The user is not logged in return false
            s1.logout("Nati");
            bool ans3 = s1.openStore("storeName2", "Nati");
            Assert.AreEqual(ans3, false);

            ServiceLayer.System.Reset();

        }
    }
}