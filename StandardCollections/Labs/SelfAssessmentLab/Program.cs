using System;
using System.Collections;

namespace SelfAssessmentLab
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList studentList = GetStudentArrayList();
            foreach(var item in studentList){
                var student = (Student)item;
                Console.WriteLine($"Student First: {student.FirstName}, Last: {student.LastName}");
            }            
        }

        static ArrayList GetStudentArrayList(){
            var studentList = new ArrayList();

            // First student.
            var student1Grades = new Stack();
            student1Grades.Push("A");
            student1Grades.Push("A");
            student1Grades.Push("A");
            student1Grades.Push("A");
            student1Grades.Push("A");
            studentList.Add(new Student(){
                Id = "ABC123",
                FirstName = "Jack",
                LastName = "Sparrow",
                Grades = student1Grades
            });

            // Second student.
            var student2Grades = new Stack();
            student2Grades.Push("B");
            student2Grades.Push("C");
            student2Grades.Push("D");
            student2Grades.Push("A");
            student2Grades.Push("B");
            studentList.Add(new Student(){
                Id = "CBA321",
                FirstName = "John",
                LastName = "Wick",
                Grades = student2Grades
            });

            // Third student.
            var student3Grades = new Stack();
            student3Grades.Push("F");
            student3Grades.Push("F");
            student3Grades.Push("F");
            student3Grades.Push("F");
            student3Grades.Push("F");
            studentList.Add(new Student(){
                Id = "ABC321",
                FirstName = "Red",
                LastName = "Cyclone",
                Grades = student3Grades
            });

            return studentList;
        }
    }
}
