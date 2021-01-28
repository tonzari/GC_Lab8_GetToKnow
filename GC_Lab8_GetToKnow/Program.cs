using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace GC_Lab8_GetToKnow
{
    class Program
    {
        public static string studentDataRawText;
        public static List<string> studentListUnparsed;
        public static List<Student> studentList;

        public static string userInput;
        public static int userNumber;

        static void Main(string[] args)
        {
            

            InitializeData();

            RunTestPrintAllStudentData(studentList);

            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about? (enter a number 1-12): ");

            userNumber = GetAndValidateUserNumber();

            Console.WriteLine($"Student {userNumber} is {studentList[userNumber]}. What would you like to know about {studentList[userNumber]}? (enter “hometown” or“favorite food”):");


            
            Console.WriteLine("That data does not exist. Please try again. (enter “hometown” or “favorite food”): ");
            Console.WriteLine("Kim is from Detroit, MI. Would you like to know more? (enter “yes” or “no”): ");
            



            ExitApp();
        }

        private static void InitializeData()
        {
            studentDataRawText = GetStudentDataFromTextFile();
            studentListUnparsed = PopulateListLineByLine(studentDataRawText);
            studentList = GenerateStudentsInList(studentListUnparsed);
        }

        public static List<Student> GenerateStudentsInList (List<string> unparsedList)
        {
            List<Student> studentList = new List<Student>();

            foreach (string line in unparsedList)
            {
                string[] data = line.Split('/');

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Trim();
                    Console.WriteLine(i + " " + data[i]);
                }

                studentList.Add(new Student(data[0], data[1], data[2], data[3]));
            }

            return studentList;
        }

        public static List<string> PopulateListLineByLine(string data)
        {
            string[] singleLines = data.Split(new[] { Environment.NewLine}, StringSplitOptions.None);

            return singleLines.ToList();
        }

        public static string GetStudentDataFromTextFile()
        {
            string fileName = "StudentData.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            return File.ReadAllText(path);
        }

        public static int GetAndValidateUserNumber()
        {
            userInput = Console.ReadLine();
            try
            {
                if (Int32.TryParse(userInput, out int userNumber) && userNumber >= 1 && userNumber <= 12)
                {
                    //good
                    return userNumber;
                }
                else
                {
                    throw new Exception("Invalid input. Please try again. (Enter a number 1 - 12)");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return GetAndValidateUserNumber();
            }
        }

        public static void ExitApp()
        {
            Console.WriteLine("Thanks!");
            Console.WriteLine("Exiting application...");
        }

        #region TESTS
       
        private static void RunTestPrintAllStudentData(List<Student> studentList)
        {
            foreach (Student s in studentList)
            {
                Console.WriteLine(s.firstName);
                Console.WriteLine(s.lastName);
                Console.WriteLine(s.hometown);
                Console.WriteLine(s.favFood);
            }
        }

        #endregion
    }
}