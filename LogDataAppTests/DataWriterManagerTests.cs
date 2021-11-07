using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace LogDataApp.Tests
{
    [TestClass()]
    public class DataWriterManagerTests
    {
        [TestMethod()]
        public void DataWriterManagerSingleTest()
        {

            DataWriterManager DataWriter = new("F");
            List<IDataLogger> Loggers = DataWriter.ReturnLoggers();
            IDataLogger FileLogger = new LogToFile();

            Assert.AreEqual(Loggers[0].GetType(), FileLogger.GetType());
        }
        [TestMethod()]
        public void DataWriterManagerMultipleTest()
        {

            DataWriterManager DataWriter = new("A");
            List<IDataLogger> Loggers = DataWriter.ReturnLoggers();
            List<IDataLogger> LoggersTest = new() { new LogToConsole(), new LogToFile(), new LogToWindowsEventLog() };

            for (int i = 0; i < Loggers.Count; i++)
                Assert.AreEqual(Loggers[i].GetType(), LoggersTest[i].GetType());
        }
    }
}