using NUnit.Framework;
using ServiceLayer;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Initialize()
        {
            ServiceLayer.System sys = (ServiceLayer.System.initialize("", "123456"));
            Assert.AreEqual(sys.initialized, false);
            ServiceLayer.System.Reset();
            sys = (ServiceLayer.System.initialize("moti", "123456"));

            Assert.AreEqual(sys.initialized, true);

            ServiceLayer.System.Reset();
        }

        [Test]
        public void Register()
        {

            ServiceLayer.System sys = (ServiceLayer.System.initialize("moti", "123456"));
            Assert.AreEqual(sys.initialized, true);

            Assert.AreEqual(sys.register("yael", "123456"), true);
            Assert.AreEqual(sys.register("yael", "123l56"), false);


        }
    }
}