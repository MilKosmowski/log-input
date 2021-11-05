using System;
using System.Collections.Generic;

namespace LogDataApp
{
    class DataWriterProxy
    {
        private char logOption;
        private string logPriority;
        List<IDataWriter> Writers;

        public DataWriterProxy (char logOption, string logPriority)
        {
            this.logOption = logOption;
            this.logPriority = logPriority;

            switch (logOption)
            {
                case ('C'):
                    Writers.Add(new LogToConsole());
                    break;
                case ('F'):
                    Writers.Add(new LogToFile());
                    break;
                case ('E'):
                    Writers.Add(new LogToEventLog());
                    break;
                default:
                    Writers.Add(new LogToConsole());
                    Writers.Add(new LogToFile());
                    Writers.Add(new LogToEventLog());
                    break;

            }
        }

        internal void Write(string userInput)
        {
            foreach (var WriterType in Writers)
            {
                WriterType.WriteData(userInput, logPriority);
            }
        }
    }
}