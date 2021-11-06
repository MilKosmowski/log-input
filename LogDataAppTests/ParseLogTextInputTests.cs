using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class ParseLogTextInputTests
    {
        [TestMethod()]
        public void ParseTestOk()
        {
            InterpreInput Parse = new TextInputInterpret();
            Assert.AreEqual(Parse.Interpret("Raz dwa trzy"), "Raz dwa trzy");
        }

        [TestMethod()]
        public void ParseTestNull()
        {
            InterpreInput Parse = new TextInputInterpret();
            Assert.AreEqual(Parse.Interpret(null), "");
        }
    }
}