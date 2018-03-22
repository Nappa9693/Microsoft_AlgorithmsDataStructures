using System;

namespace TutorialLabOne{
    public class Student{
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Age {get; set;}
        public string Program {get; set;}

        public Student(string first, string last, int age, string prog)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
            this.Program = prog;
        }
    }
}