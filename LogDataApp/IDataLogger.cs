﻿using System;
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
            using StreamWriter sw = File.AppendText($"fileInfo");
            sw.WriteLine("{0} | {1} | {2}",
                DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);
        }
    }

    public class LogToWindowsEventLog : IDataLogger
    {
        public void LogData(string userInput, string logPriority)
        {
            if (OperatingSystem.IsWindows())
            {
                EventLog myLog = new EventLog();
                EventLogEntryType _eventLogEntryType = logPriority switch
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