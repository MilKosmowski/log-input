using System;
using System.Linq;

namespace LogDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------LOG USER INPUT------------\n\n" +
                              "Which type of logging do You choose?: \n\n" +

                              "(C)onsole logging,\n" +
                              "(F)ile logging,\n" +
                              "(E)vent logging,\n" +
                              "Default -> (A)ll of the above\n\n" +

                              "Input a letter:  ");

            UserInput = Char.ToUpper(Convert.ToChar(Console.Read()));

            Console.WriteLine($"Option chosen: {userInput}. Input text to be logged:\n");

            ILog logger = new LogToConsole(userInput);
            Console.ReadLine();
        }

        public static char UserInput
        {
            get { return userInput; }
            set { if (logOptions.Contains(value)) userInput = value;}
        }

        private static char userInput = 'A';
        private static char[] logOptions = {'C','F','E','A'};
    }
}
