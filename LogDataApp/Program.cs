using System;
using System.Collections.Generic;

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
                              "(E)vent logging. Saved to Application and Services Logs/DataAppLog,\n" +
                              "Default -> (A)ll of the above\n\n" +

                              "Set logging method (C,F,E,A):");

            using (var Input = new TypeInputInterpret())
                do { _logOption = Input.Interpret(Console.ReadLine()); }
                while (_logOption == "N");

            ChooseLogPriority();
        }

        private static void ChooseLogPriority()
        {
            LogPriorityDictionary.Add("1", "Fatal");
            LogPriorityDictionary.Add("2", "Error");
            LogPriorityDictionary.Add("3", "Warning");
            LogPriorityDictionary.Add("4", "Info");
            LogPriorityDictionary.Add("5", "Debug");
            LogPriorityDictionary.Add("6", "Trace");
            LogPriorityDictionary.Add("", "Trace");

            Console.WriteLine("Choose log priority:");

            foreach (KeyValuePair<string, string> entry in LogPriorityDictionary)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

           Console.WriteLine("Set log priority (1-6):");

            using (var Input = new PriorityInputInterpret(LogPriorityDictionary))
                do { _logPriority = Input.Interpret(Console.ReadLine()); }
                while (_logPriority == "");
            LogWriter = new DataWriterManager(_logOption, _logPriority);
            InputLogText();
        }

        private static void InputLogText()
        {
            Console.WriteLine("Write log text:\n");
            using (var Input = new TextInputInterpret())
                do
                {
                    _logResult = Input.RunLogWriter(Console.ReadLine(), LogWriter);
                    Console.WriteLine("Write log text:\n");
                }
                while (_logResult != "Q");

            Environment.Exit(0);
        }

        #endregion Methods

        private static string _logOption;
        private static string _logPriority;
        private static string _logResult;
        private static DataWriterManager LogWriter;
        static Dictionary<string, string> LogPriorityDictionary = new Dictionary<string, string>();
    }
}