using System;
using System.Diagnostics;
using System.IO;

namespace LogDataApp
{
    public interface IDataWriter
    {
        public void WriteData(string userInput, string logPriority);
    }

    public class LogToConsole : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            Console.WriteLine("{0} | {1} | {2}",
                              DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
        }
    }

    public class LogToFile : IDataWriter
    {
        public void WriteData(string userInput, string logPriority)
        {
            sw.WriteLine("{0} | {1} | {2}",
                         DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
            sw.Flush();
        }

        private StreamWriter sw = new StreamWriter($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt", true);
    }

    public class LogToEventLog : IDataWriter
    {
        private EventLog myLog = new EventLog();

        private EventLogEntryType _eventLogEntryType;

        public void WriteData(string userInput, string logPriority)
        {
            if (OperatingSystem.IsWindows())
            {
                _eventLogEntryType = logPriority switch
                {
                    "Fatal" or "Error" => EventLogEntryType.Error,
                    "Warning" => EventLogEntryType.Warning,
                    "Info" or "Debug" or _ => EventLogEntryType.Information
                };

                if (!EventLog.SourceExists("LogDataApp"))
                    EventLog.CreateEventSource("LogDataApp", "DataAppLogs");

                myLog.Source = "LogDataApp";
                myLog.WriteEntry(userInput, _eventLogEntryType);
            }
        }
    }
}