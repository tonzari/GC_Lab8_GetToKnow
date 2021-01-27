using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab8_GetToKnow
{
    public class Student
    {
        //int id;
        public string fullName;
        public string hometown;
        public string favFood;

        public Student(string name, string hometowm, string favFood)
        {
            fullName = name;
            this.hometown = hometown;
            this.favFood = favFood;
        }
    }
}
