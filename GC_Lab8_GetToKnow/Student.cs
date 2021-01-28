using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab8_GetToKnow
{
    public class Student
    {
        //int id;
        public string firstName;
        public string lastName;
        public string hometown;
        public string favFood;

        public Student(string FirstName, string LastName, string HomeTown, string FavFood)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.hometown = HomeTown;
            this.favFood = FavFood;
        }
    }
}
