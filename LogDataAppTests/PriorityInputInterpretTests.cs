using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class PriorityInputInterpretTests
    {
        [TestMethod()]
        public void ParseTestFatal()
        {
            Dictionary<string, string> LogPriorityDictionary = new Dictionary<string, string>();
            LogPriorityDictionary.Add("1", "Fatal");
            InterpreInput Interpret = new PriorityInputInterpret(LogPriorityDictionary);
            Assert.AreEqual(Interpret.Interpret("1"), "Fatal");
        }
        [TestMethod()]
        public void ParseTestNull()
        {
            Dictionary<string, string> LogPriorityDictionary = new Dictionary<string, string>();
            InterpreInput Interpret = new PriorityInputInterpret(LogPriorityDictionary);
            Assert.AreEqual(Interpret.Interpret(null), "");
        }
    }
}