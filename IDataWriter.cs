using System;
using System.Diagnostics;
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
            sw.Flush();
        }

        private StreamWriter sw = new StreamWriter($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt");
    }

    internal class LogToEventLog : IDataWriter
    {
        EventLog myLog = new EventLog();

        EventLogEntryType _eventLogEntryType;

        public void WriteData(string userInput, string logPriority)
        {
            _eventLogEntryType = logPriority switch
            {
                "Fatal" or "Error" => EventLogEntryType.Error,
                "Warning" => EventLogEntryType.Warning,
                "Info" or "Debug" or _ => EventLogEntryType.Information
            };
            myLog.Source = "WinService";
            myLog.Log = "WinServiceLog";
            myLog.WriteEntry(userInput, _eventLogEntryType);

        }
    }
}