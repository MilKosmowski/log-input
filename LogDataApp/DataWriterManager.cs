using System.Collections.Generic;

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
                    Writers.Add(new LogToEventLog());
                    break;

                default:
                    Writers.Add(new LogToConsole());
                    Writers.Add(new LogToFile());
                    Writers.Add(new LogToEventLog());
                    break;
            }

            foreach (var WriterType in Writers)
            {
                WriterType.LogData(userInput, logPriority);
            }
            Writers.Clear();
        }
    }
}