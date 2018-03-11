using System;
using System.Linq;

namespace TutorialLabThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[5];
            numbers[0] = 2;
            numbers[1] = 5;
            numbers[2] = 9;
            numbers[3] = 6;
            numbers[4] = 7;

            // Accessing items in the array by index.
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[3]);
            Console.WriteLine(numbers[2]);

            // Access items in the array by index using a for loop and calculating a total.
            int total = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                total = total + numbers[i];
            }
            Console.WriteLine(total.ToString());

            // This was not in the lab but I thought I would deviate a bit ;)
            // Note: This will get the same result as above but with less code than
            // the foreach loop suggested in the lab.
            int sum = numbers.Sum();
            Console.WriteLine(sum.ToString());
        }
    }
}
