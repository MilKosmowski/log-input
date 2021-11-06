using System.Collections.Generic;

namespace LogDataApp
{
    public class DataWriterProxy
    {
        private string logOption;
        private string logPriority;
        private List<IDataWriter> Writers = new List<IDataWriter>();

        public DataWriterProxy(string logOption, string logPriority)
        {
            this.logOption = logOption;
            this.logPriority = logPriority;

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
        }

        public void Write(string userInput)
        {
            foreach (var WriterType in Writers)
            {
                WriterType.WriteData(userInput, logPriority);
            }
        }
    }
}