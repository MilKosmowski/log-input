using System;
using System.IO;

namespace LogDataApp
{
    internal interface IDataWriter
    {
        public void WriteData(string userInput, string logPriority);
    }

    class LogToConsole : IDataWriter
    {

        public void WriteData(string userInput, string logPriority)
        {
            System.Console.WriteLine($"{DateTime.Now,-10} - {userInput}");
        }
    }
    class LogToFile : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            sw.WriteLine($"{0} | {1} | {2}", 
                         DateTime.Now.ToString("HH-mm-ss"), logPriority, logPriority);
        }

        StreamWriter sw = new StreamWriter($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt", append: true);
    }
    class LogToEventLog : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            throw new NotImplementedException();
        }
    }

}
