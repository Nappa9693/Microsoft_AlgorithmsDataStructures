using System;

namespace Module2Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                var students = new Student[5];

                // Assign values to the first student in the students array.
                students[0] = new Student();
                students[0].ID = "A333-222-111";
                students[0].Name = "Captain Jack Sparrow";
                Console.WriteLine($"First student ID: {students[0].ID}");
                Console.WriteLine($"First student Name: {students[0].Name}");

                // Add remaining students to the array.
                var additionalStudents = GetRemainingStudents();
                for(int i=1; i < students.Length; i++){
                    students[i] = additionalStudents[i-1];
                }

                // Output the students.
                foreach(var student in students){
                    Console.WriteLine($"Student ID: {student.ID}, Name: {student.Name}");
                }
            }catch(Exception ex){
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        static Student[] GetRemainingStudents(){
            return new Student[]{
                new Student(){
                    ID = "B222-333-444",
                    Name = "Bob"
                },
                new Student(){
                    ID = "C333-444-555-666",
                    Name = "Jack"
                },
                new Student(){
                    ID = "D444-555-666-777",
                    Name = "Nappa"
                },
                new Student(){
                    ID = "E666-777-888",
                    Name = "Vegeta"
                }
            };
        }
    }
}
