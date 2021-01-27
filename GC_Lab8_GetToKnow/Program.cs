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
/*
Ramon Guarnes / Tigard, OR / Burgers
Antonio Manzari / Beverly Hills, MI / Focaccia Barese
Joshua Carolin / Novi, MI / Naleśniki
Nick D'Oria / Canton, MI / Tacos
Jeremiah Wyeth / Crystal, MI / Burgers
Wendi Magee / Detroit, MI / Salami
Juliana / Denver, CO / Tacos
Nathaniel Davis / Berkley, MI / Steak
Tommy Waalkes / Raleigh, NC / Chicken Curry
Grace Symore / Mesa, AZ / Sweet Potato Fries
Jeffrey Wohlfield / Detroit, MI / Steak
Josh Gallentine / Baldwin, MI / Falafel
*/