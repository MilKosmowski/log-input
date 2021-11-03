using System;

namespace LogDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which type of logging do You choose?: \n\n " +

                              "(C)onsole logging,\n" +
                              "(F)ile logging,\n" +
                              "(A)ll of the above?\n");
            UserInput = Console.Read().ToString();

        }

        public static char UserInput 
        {
            get {return userInput;}
            set { if () userInput = value; }
        }
        private static char userInput; 
    }
}
