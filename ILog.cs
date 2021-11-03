using System;

namespace LogDataApp
{
    internal interface ILog
    {
        public void ExecuteLogging(string userInput);

    }

    internal abstract class LogGeneric : ILog
    {
        public LogGeneric(string userInput) => this.userInput = userInput;
        public abstract void ExecuteLogging(string userInput);

        protected string userInput;
    }
    class LogToConsole : LogGeneric
    {
        LogToConsole(string userInput) : base(userInput) { }

        public override void ExecuteLogging(string userInput)
        {
            System.Console.WriteLine($"{DateTime.Now,-10} - {userInput}");
        }
    }
    class LogToFile : LogGeneric
    {
        LogToFile(string userInput) : base(userInput) { }

        public override void ExecuteLogging(string userInput)
        {
            System.Console.WriteLine($"{DateTime.Now,-10} - {userInput}");
        }
    }
    class LogToEventLog : LogGeneric
    {
        LogToEventLog(string userInput) : base(userInput) { }

        public override void ExecuteLogging(string userInput)
        {
            System.Console.WriteLine($"{DateTime.Now,-10} - {userInput}");
        }
    }

}
