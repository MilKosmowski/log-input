using System;
using System.IO;

namespace LogDataApp
{
    internal interface IDataWriter
    {
        public void WriteData(string userInput, string logPriority);
    }

    internal class LogToConsole : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            Console.WriteLine("{0} | {1} | {2}",
                              DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
        }
    }

    internal class LogToFile : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            sw.WriteLine("{0} | {1} | {2}",
                         DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
            sw.Close();
        }

        private StreamWriter sw = new StreamWriter($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt");
    }

    internal class LogToEventLog : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            throw new NotImplementedException();
        }
    }
}