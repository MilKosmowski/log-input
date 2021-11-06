using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class ParseLogTypeInputTests
    {
        [TestMethod()]
        public void ParseTestOk()
        {
            ParseLog Parse = new ParseLogTypeInput();
            Assert.AreEqual(Parse.Parse("A"), "A");
        }

        [TestMethod()]
        public void ParseTestN()
        {
            ParseLog Parse = new ParseLogTypeInput();
            Assert.AreEqual(Parse.Parse("f"), "N");
        }

        [TestMethod()]
        public void ParseTestEmpty()
        {
            ParseLog Parse = new ParseLogTypeInput();
            Assert.AreEqual(Parse.Parse(""), "A");
        }
    }
}