using System;
using System.Linq;

namespace LogDataApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("-----------LOG USER INPUT------------\n\n");
            ChooseLogType();
        }

        #region Methods

        private static void ChooseLogType()
        {
            Console.WriteLine("Input logging method: \n" +
                              "(C)onsole logging,\n" +
                              "(F)ile logging. Saved to \"Log (current date).txt\",\n" +
                              "(E)vent logging,\n" +
                              "Default -> (A)ll of the above\n\n" +

                              "Set logging method (C,F,E,A):");

            using (var Input = new ParseLogTypeInput())
                do { _logOption = Input.Parse(Console.ReadLine()); }
                while (_logOption == "N");
            
            ChooseLogPriority();

        }

        private static void ChooseLogPriority()
        {
            Console.WriteLine("Choose log priority:\n" +
                              "1 - Fatal\n" +
                              "2 - Error\n" +
                              "3 - Warning\n" +
                              "4 - Info\n" +
                              "5 - Debug\n" +
                              "Default -> 6 - Trace\n\n" +

                              "Set log priority (1-6):");

            using (var Input = new ParseLogPriorityInput())
                do { _logPriority = Input.Parse(Console.ReadLine()); }
                while (_logPriority == "");
            LogWriter = new DataWriterProxy(_logOption, _logPriority);
            InputLog();
        }

        private static void InputLog()
        {
            Console.WriteLine("Write log text:\n");
            using (var Input = new ParseLogTextInput())
                do 
                { 
                    _logResult = Input.Parse(Console.ReadLine(), LogWriter); 
                    Console.WriteLine("Write log text:\n"); 
                }
                while (_logResult != "Q");

            Environment.Exit(0);
        }

        #endregion Methods

        static string _logOption;
        static string _logPriority;
        static string _logResult;
        private static DataWriterProxy LogWriter;
    }
}