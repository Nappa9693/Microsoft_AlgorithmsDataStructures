using System;
using System.Collections.Generic;

namespace SelfAssessment{
    public class Student{
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Age {get; set;}
        public string Program {get; set;}
        public SortedList<int, string> Grades {get; set;}
    }
}