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
            InputLogText();
        }

        private static void InputLogText()
        {
            Console.WriteLine("Write log text:\n");
            using (var Input = new TextInputInterpret())
                do
                {
                    _logText = Input.Interpret(Console.ReadLine());

                    LogWriters = new DataWriterManager(_logOption);
                    foreach (IDataLogger Loggger in LogWriters.ReturnLoggers())
                        Loggger.LogData(_logText, _logPriority);

                    Console.WriteLine("Write log text:\n");
                }
                while (_logText.ToUpper() != "Q");

            Environment.Exit(0);
        }

        private static string _logOption;
        private static string _logPriority;
        private static string _logText;
        private static DataWriterManager LogWriters;
        static Dictionary<string, string> LogPriorityDictionary = new Dictionary<string, string>();
    }
}