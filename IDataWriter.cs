using System;
using System.IO;

namespace LogDataApp
{
    internal interface IDataWriter
    {
        public void WriteData(string userInput);
    }

    class LogToConsole : IDataWriter
    {

        public void WriteData(string userInput)
        {
            System.Console.WriteLine($"{DateTime.Now,-10} - {userInput}");
        }
    }
    class LogToFile : IDataWriter
    {

        public void WriteData(string userInput)
        {
            using StreamWriter sw = new StreamWriter($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt")
            {

            };
        }
    }
    class LogToEventLog : IDataWriter
    {

        public void WriteData(string userInput)
        {
            System.Console.WriteLine($"{DateTime.Now,-10} - {userInput}");
        }
    }

}
