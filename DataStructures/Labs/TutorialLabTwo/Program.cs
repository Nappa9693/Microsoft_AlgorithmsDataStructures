using System;

namespace TutorialLabTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);
            Console.WriteLine(Days.Thu);
        }
    }
}
