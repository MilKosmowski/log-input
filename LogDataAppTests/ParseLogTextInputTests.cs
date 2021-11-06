using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class ParseLogTextInputTests
    {
        [TestMethod()]
        public void ParseTestOk()
        {
            ParseLog Parse = new ParseLogTextInput();
            Assert.AreEqual(Parse.Parse("Raz dwa trzy"), "Raz dwa trzy");
        }

        [TestMethod()]
        public void ParseTestNull()
        {
            ParseLog Parse = new ParseLogTextInput();
            Assert.AreEqual(Parse.Parse(null), "");
        }
    }
}