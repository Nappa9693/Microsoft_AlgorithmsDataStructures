using System;
using System.Collections;

namespace TutorialLabOne
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstArrayListExample();
            SecondArrayListExample();
            Step13();
        }

        static void FirstArrayListExample(){
            ArrayList myArrList = new ArrayList();
            myArrList.Add("First Item");
            myArrList.Add(3);
            myArrList.Add(4.5);

            foreach(object obj in myArrList)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        static void SecondArrayListExample(){
            ArrayList myArrList = new ArrayList();
            myArrList.Add("First Item");
            myArrList.Add("Third Item");
            myArrList.Add("Second Item");

            myArrList.Sort();
            int itemIndex = myArrList.IndexOf("Third Item");

            foreach(object obj in myArrList)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine();
            Console.WriteLine($"Third Item is at index {itemIndex}.");
        }

        static void Step13(){
            try{
                ArrayList myArrList = new ArrayList();
                myArrList.Add("First Item");
                myArrList.Add(3);
                myArrList.Add(4.5);

                // Throws exception because you cannot sort objects
                // which is what the values are stored as.
                myArrList.Sort();
            }catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
