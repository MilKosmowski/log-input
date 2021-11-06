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
            using (StreamWriter sw = File.AppendText($"fileInfo"))
                sw.WriteLine("{0} | {1} | {2}",
                    DateTime.Now.ToString("HH:mm:ss"), logPriority, userInput);

           // sw.Flush();
        }

        private StreamWriter sw;
    }

    public class LogToWindowsEventLog : IDataLogger
    {

        private readonly EventLog myLog;

        private readonly EventLogEntryType _eventLogEntryType;

        public LogToWindowsEventLog(EventLog myLog, EventLogEntryType eventLogEntryType)
        {
            this.myLog = myLog;
            _eventLogEntryType = eventLogEntryType;
        }

        public void LogData(string userInput, string logPriority)
        {
                myLog.WriteEntry(userInput, _eventLogEntryType);
            
        }
    }
}