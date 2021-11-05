using System;
using System.Linq;

namespace LogDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ChooseLogType();
        }

        #region Methods
        private static void ChooseLogType()
        {
            LogOption = 'A';

            Console.WriteLine("-----------LOG USER INPUT------------\n\n" +

                              "Which type of logging do You choose?: \n\n" +

                              "(C)onsole logging,\n" +
                              "(F)ile logging,\n" +
                              "(E)vent logging,\n" +
                              "Default -> (A)ll of the above\n\n" +

                              "Input a letter:  ");


            ParseLogTypeInput(Console.Read());



        }
        private static void ParseLogTypeInput(int logTypeInput)
        {
            LogOption = Convert.ToChar(logTypeInput);

            if (LogOption.Equals('N'))
            {
                Console.WriteLine("Try again.");
                ChooseLogType();
            }
            else
                ChooseLogPriority();
        }
        private static void ChooseLogPriority()
        {

            Console.WriteLine("Log priorities:\n" +
                              "1 - Fatal\n" +
                              "2 - Error\n" +
                              "3 - Warn\n" +
                              "4 - Info\n" +
                              "5 - Debug\n" +
                              "6 - Trace\n" +
                              "Default - Trace\n\n" +
                              "Set log priority (1-6):");

            ParselogPriorityInput(Console.ReadLine());
        }
        private static void ParselogPriorityInput(string logPriorityInput)
        {
            LogPriority = logPriorityInput;

            if (LogPriority == "")
            {
                Console.WriteLine("Try again.");
                ChooseLogPriority();
            }
            else
            {
                LogWriter = new DataWriterProxy(LogOption, LogPriority);
                InputLog();
            }
        }
        private static void InputLog()
        {
            Console.WriteLine($"\nOption chosen: {LogOption}, Log priority: {LogPriority}. Input text to be logged and press Enter. Input Q to stop:");

            ParseLogTextInput(Console.ReadLine());
        }
        private static void ParseLogTextInput(string logTextInput)
        {
            UserInput = logTextInput;

            if (UserInput == "")
                Console.WriteLine("Try again.");
            else
            {
                LogWriter.Write(UserInput);
                Console.WriteLine("Log/s written succesfully.");
            }
            InputLog();
        }
        #endregion

        #region Properties
        private static char LogOption
        {
            get { return _logOption; }
            set { if (value.Equals(null)) _logOption = 'A'; if (_logOptions.Contains(Char.ToUpper(value))) _logOption = value; else _logOption = 'N'; }
        }

        private static string LogPriority
        {
            get { return _logPriority; }
            set { 
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
        private static string UserInput
        {
            get { return _userInput; }
            set { if (value == "Q" || value == "q") Environment.Exit(0); else _userInput = value ?? ""; }
        }
        #endregion

        #region Variables
        static char _logOption;
        static readonly char[] _logOptions = { 'C', 'F', 'E', 'A' };
        static string _userInput;
        static string _logPriority;
        static DataWriterProxy LogWriter;
        #endregion
    }
}
