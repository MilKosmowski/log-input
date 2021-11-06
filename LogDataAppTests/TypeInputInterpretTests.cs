using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class TypeInputInterpretTests
    {
        [TestMethod()]
        public void ParseTestOk()
        {
            InterpreInput Parse = new TypeInputInterpret();
            Assert.AreEqual(Parse.Interpret("A"), "A");
        }

        [TestMethod()]
        public void ParseTestN()
        {
            InterpreInput Parse = new TypeInputInterpret();
            Assert.AreEqual(Parse.Interpret("z"), "N");
        }

        [TestMethod()]
        public void ParseTestEmpty()
        {
            InterpreInput Parse = new TypeInputInterpret();
            Assert.AreEqual(Parse.Interpret(""), "A");
        }
    }
}