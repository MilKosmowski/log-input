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
                switch (value)
                {
                    case "1":
                        _logPriority = "Fatal";
                        break;

                    case "2":
                        _logPriority = "Error";
                        break;

                    case "3":
                        _logPriority = "Warn";
                        break;

                    case "4":
                        _logPriority = "Info";
                        break;

                    case "5":
                        _logPriority = "Debug";
                        break;

                    case "6":
                    case "":
                        _logPriority = "Trace";
                        break;

                    default:
                        _logPriority = "";
                        break;
                }
            }
        }

        private string _logPriority;
    }
}