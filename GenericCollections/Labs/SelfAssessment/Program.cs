using System;
using System.Collections.Generic;

namespace SelfAssessment
{
    class Program
    {
        public static readonly string[] PossibleGrades = new string[]{
            "A", "B", "C", "D", "F"
        };

        static void Main(string[] args)
        {
            var students = GetStudents();
            OutputStudentsFirstAndLastNames(students);
            OutputStudentNamesAndGrades(students);
        }

        static void OutputStudentNamesAndGrades(List<Student> students){
            foreach(var student in students){
                Console.WriteLine($"First Name: {student.FirstName}, Last Name: {student.LastName}");
                Console.WriteLine("Grades:");
                foreach(var gradeKey in student.Grades.Keys){
                    Console.WriteLine(student.Grades[gradeKey]);
                }
            }
        }

        static void OutputStudentsFirstAndLastNames(List<Student> students){
            foreach(var student in students){
                Console.WriteLine($"First Name: {student.FirstName}, Last Name: {student.LastName}");
            }
        }

        static List<Student> GetStudents(){
            var students = new List<Student>();

            students.Add(GetStudent(
                firstName: "Jack",
                lastName: "Sparrow",
                age: 40,
                program: "Pillaging"
            ));
            students.Add(GetStudent(
                firstName: "Dexter",
                lastName: "???",
                age: 7,
                program: "Genius"
            ));
            students.Add(GetStudent(
                firstName: "Zim",
                lastName: "???",
                age: 20,
                program: "Invader"
            ));

            return students;
        }

        static Student GetStudent(string firstName, string lastName, int age, string program){
            var student = new Student(){
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Program = program
            };
            student.Grades = GetRandomGrades();
            
            return student;
        }

        static SortedList<int, string> GetRandomGrades(){
            var grades = new SortedList<int,string>();
            var randomNumberGenerator = new Random();
            const int minimumRandomLowerBound = 0;
            const int maximumRandomUpperBound = 5;
            
            for(int index=0; index < 5; index++){
                grades.Add(index, PossibleGrades[randomNumberGenerator
                    .Next(minimumRandomLowerBound, maximumRandomUpperBound)]);
            }

            return grades;
        }
    }
}
