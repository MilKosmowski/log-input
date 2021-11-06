using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogDataApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogDataApp.Tests
{
    [TestClass()]
    public class DataWriterManagerTests
    {
        [TestMethod()]
        public void DataWriterManagerTestFile()
        {
            DataWriterManager DataWriter = new DataWriterManager("F", "Info");
            DataWriter.Write("Test text");
            string[] LogText = File.ReadAllLines($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt");
            Assert.IsTrue(LogText.Any(l => l.Contains(" | Info | Test text")));
        }
        [TestCleanup()]
        public void DataWriterManagerTestCleanup()
        {
            File.Delete($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt");
        }
    }
}