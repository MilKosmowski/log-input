using System;

namespace LogDataApp
{
    class ParseLogPriorityInput : ParseLog
    {
        public override string Parse(string logPriorityInput)
        {
            LogPriority = logPriorityInput;
            return LogPriority;
        }

        private string LogPriority
        {
            get { return _logPriority; }
            set
            {
                _logPriority = value switch
                {
                    "1" => "Fatal",
                    "2" => "Error",
                    "3" => "Warning",
                    "4" => "Info",
                    "5" => "Debug",
                    "6" or "" => "Trace",
                    _ => "",
                };
            }
        }

        private string _logPriority;
    }
}