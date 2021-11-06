using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class ParseLogPriorityInputTests
    {
        [TestMethod()]
        public void ParseTestFatal()
        {
            ParseLog Parse = new ParseLogPriorityInput();
            Assert.AreEqual(Parse.Parse("1"), "Fatal");
        }

        [TestMethod()]
        public void ParseTestTrace()
        {
            ParseLog Parse = new ParseLogPriorityInput();
            Assert.AreEqual(Parse.Parse("6"), "Trace");
        }

        public void ParseTestEmpty()
        {
            ParseLog Parse = new ParseLogPriorityInput();
            Assert.AreEqual(Parse.Parse(""), "Trace");
        }

        public void ParseTestNull()
        {
            ParseLog Parse = new ParseLogPriorityInput();
            Assert.AreEqual(Parse.Parse(null), "");
        }
    }
}