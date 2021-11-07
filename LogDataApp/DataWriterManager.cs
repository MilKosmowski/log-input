using System.Collections.Generic;

namespace LogDataApp
{
    public class DataWriterManager
    {
        private string logOption;
        private string logPriority;
        private List<IDataLogger> Writers = new List<IDataLogger>();

        public DataWriterManager(string logOption)
        {
            this.logOption = logOption;
        }

        public List<IDataLogger> ReturnLoggers()
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
                    Writers.Add(new LogToWindowsEventLog());
                    break;

                default:
                    Writers.Add(new LogToConsole());
                    Writers.Add(new LogToFile());
                    Writers.Add(new LogToWindowsEventLog());
                    break;
            }

            return Writers;
        }
    }
}