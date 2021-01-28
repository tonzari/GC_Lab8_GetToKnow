using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace GC_Lab8_GetToKnow
{
    class Program
    {
        // Grand Circus Lab 8 - Get to know your classmates
        // Antonio Manzari

        public static List<string> studentListUnparsed;
        public static List<Student> studentList;

        public static string userInput;
        public static int userNumber;
        public static bool userWantsToContinue = false;

        static void Main(string[] args)
        {
            InitializeData();

            Console.WriteLine("Welcome to our lovely C# class!");

            do
            {
                GetToKnowStudents();

            } while (userWantsToContinue);

            ExitApp();
        }

        #region METHODS
        private static void GetToKnowStudents()
        {
            // Choose student by number
            Console.WriteLine("Which student would you like to learn more about? (Enter their first name or enter a number 1-12)");
            userNumber = ProcessStudentSearchInput();
            Student student = studentList[userNumber];
            Console.WriteLine(Environment.NewLine);


            // Reveal student, ask what user would like to know
            Console.WriteLine($"Student {userNumber + 1} is {student.firstName} {student.lastName}. What would you like to know about {student.firstName}? (enter “hometown” or “favorite food”)");
            userInput = GetAndValidateUserStringInput("hometown", "favorite food");
            Console.WriteLine(Environment.NewLine);


            // Provide appropriate data per user's request, and ask to contine
            if (userInput.Equals("hometown"))
            {
                Console.WriteLine($"{student.firstName} is from {student.hometown}. Would you like to know more? (Enter “yes” or “no”) ");
            }
            if (userInput.Equals("favorite food"))
            {
                Console.WriteLine($"{student.firstName}'s favorite food is {student.favFood}. YUM! Would you like to know more? (Enter “yes” or “no”)");
            }
            userInput = GetAndValidateUserStringInput("yes", "no");
            Console.WriteLine(Environment.NewLine);


            // Restart or quit app per user's request
            if (userInput.Equals("yes"))
            {
                userWantsToContinue = true;
            }
            else if (userInput.Equals("no"))
            {
                userWantsToContinue = false;
            }
        }

        public static int SearchByFirstName(string firstName)
        {
            for (int i = 0; i < studentList.Count; i++)
            {
                if (firstName.Equals(studentList[i].firstName.ToLower()))
                {
                    return i;
                }
            }

            Console.WriteLine("Sorry, we couldn't find a student with that first name. Try again. (Enter their first name or enter a number 1-12)");

            return ProcessStudentSearchInput();
        }

        public static int ProcessStudentSearchInput()
        {
            userInput = Console.ReadLine().ToLower();
            bool inputIsNumber = false;

            foreach (char c in userInput)
            {
                if (Char.IsNumber(c))
                {
                    inputIsNumber = true;
                }
            }

            if (inputIsNumber)
            {
                return ValidateUserNumber() - 1;
            }
            else
            {
                return SearchByFirstName(userInput);
            }
        }

        public static void InitializeData()
        {
            studentListUnparsed = GetStudentDataAndStoreInList();
            studentList = GenerateStudentsInList(studentListUnparsed);
        }

        public static List<Student> GenerateStudentsInList(List<string> unparsedList)
        {
            List<Student> studentList = new List<Student>();

            foreach (string line in unparsedList)
            {
                string[] data = line.Split('/');

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Trim();
                }

                studentList.Add(new Student(data[0], data[1], data[2], data[3]));
            }

            return studentList;
        }

        public static List<string> GetStudentDataAndStoreInList()
        {
            string fileName = "StudentData.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            return File.ReadAllLines(path).ToList();
        }

        public static int ValidateUserNumber()
        {
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
                return ProcessStudentSearchInput();
            }
        }

        public static string GetAndValidateUserStringInput(string response1, string response2)
        {
            userInput = Console.ReadLine().ToLower();
            try
            {
                if (userInput.Equals(response1) || userInput.Equals(response2))
                {
                    //good
                    return userInput;
                }
                else
                {
                    throw new Exception($"Invalid response. Please try again. (enter “{response1}” or “{response2}”): ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return GetAndValidateUserStringInput(response1, response2);
            }
        }

        public static void ExitApp()
        {
            Console.WriteLine("Thanks! It was nice getting to know us.");
            Console.WriteLine("Exiting application...");
        }

        #endregion

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