using System;
using System.Collections.Generic;

namespace GC_Lab8_GetToKnow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about? (enter anumber 1-20): ");
            Console.WriteLine("That student does not exist. Please try again. (enter a number 1-20)");
            Console.WriteLine("Student 10 is Kim Driscoll. What would you like to know about Kim? (enter “hometown” or“favorite food”): ");
            Console.WriteLine("That data does not exist. Please try again. (enter “hometown” or “favorite food”): ");
            Console.WriteLine("Kim is from Detroit, MI. Would you like to know more? (enter “yes” or “no”): ");

            ExitApp();
        }

        public static void ExitApp()
        {
            Console.WriteLine("Thanks!");
            Console.WriteLine("Exiting application...");
        }
    }
}