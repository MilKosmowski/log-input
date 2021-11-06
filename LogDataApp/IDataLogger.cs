using System;
using System.Diagnostics;
using System.IO;

namespace LogDataApp
{
    public interface IDataLogger
    {
        public void LogData(string userInput, string logPriority);
    }

    public class LogToConsole : IDataLogger
    {
        public void LogData(string userInput, string logPriority)
        {
            Console.WriteLine("{0} | {1} | {2}",
                              DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
        }
    }

    public class LogToFile : IDataLogger
    {
        public void LogData(string userInput, string logPriority)
        {
            sw = new StreamWriter($"Log {DateTime.Now.ToString("dd-MM-yy")}.txt", true);
            sw.WriteLine("{0} | {1} | {2}",
                         DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
            sw.Flush();
        }

        private StreamWriter sw;
    }

    public class LogToEventLog : IDataLogger
    {
        private EventLog myLog = new EventLog();

        private EventLogEntryType _eventLogEntryType;

        public void LogData(string userInput, string logPriority)
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