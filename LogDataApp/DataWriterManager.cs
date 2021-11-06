using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LogDataApp
{
    public class DataWriterManager
    {
        private string logOption;
        private string logPriority;
        private List<IDataLogger> Writers = new List<IDataLogger>();

        public DataWriterManager(string logOption, string logPriority)
        {
            this.logOption = logOption;
            this.logPriority = logPriority;
        }

        public void Write(string userInput)
        {
            switch (logOption)
            {
                case ("C"):
                    Writers.Add(new LogToConsole());
                    break;

                case ("F"):
                    Writers.Add(new LogToFile());
                    break;

                case ("E"):
                    CreateWindowsEventLog(Writers);
                    break;

                default:
                    Writers.Add(new LogToConsole());
                    Writers.Add(new LogToFile());
                    CreateWindowsEventLog(Writers);
                    break;
            }

            foreach (var WriterType in Writers)
            {
                WriterType.LogData(userInput, logPriority);
            }
            Writers.Clear();
        }

        private void CreateWindowsEventLog(List<IDataLogger> Writers)
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
                Writers.Add(new LogToWindowsEventLog(myLog, _eventLogEntryType));
            }
        }
    }
}