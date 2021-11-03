using System;

namespace LogDataApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which type of logging do You choose?: \n\n " +
                              "(C)onsole logging,\n" +
                              "(F)ile logging,\n" +
                              "(A)ll of the above.\n");
            Console.ReadLine();

        }
    }
}
