using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// This is for Topic 1 Bubble Sort and provides a small console application
// to demonstrate the Bubble sort algorithm.
// Note: I decided to take a slightly functional style with the code as evidenced by the ReadOnlyCollections
// to prevent mutation when passing references into a method.
namespace BubbleSort
{
    class Program
    {
        const int MAX_INPUT_TRIES = 3;

        static void Main(string[] args)
        {
            try
            {
                int numberCount = PromptUserForNumber("Enter the how many numbers that will be sorted:");
                ReadOnlyCollection<int> originalNumbers = BuildNumbersArray(numberCount);
                ReadOnlyCollection<int> sortedNumbers = PerformBubbleSort(originalNumbers);
                
                OutputNumbers("Before: ", originalNumbers);
                OutputNumbers("After: ", sortedNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("Press any key to quit the application.");
            Console.ReadLine();
        }

        static ReadOnlyCollection<int> PerformBubbleSort(ReadOnlyCollection<int> nums)
        {
            int[] numbers = new int[nums.Count];
            nums.CopyTo(numbers,0);

            // Use this to know when to stop the sorting routine
            bool swapped;

            // Here we use a do loop but could have used for or while loops as well.
            do
            {
                // set swapped to false so that we can ensure at least one pass on the array
                swapped = false;

                // This loop will iterate over the array from beginning to end
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    // here we use the i for the position in the array
                    // So i is the first value to compare and i + 1 compares the adjacent value
                    // Once i is incremented at the end of this loop, we compare the next two sets of values, etc.
                    if (numbers[i] > numbers[i + 1])
                    {
                        // swap routine.  Could be a separate method as well but is used inline for simplicity here
                        // temp is used to hold the right value in the comparison so we don't lose it.  That value will be replaced in the next step
                        int temp = numbers[i + 1];

                        // Here we replace the right value with the larger value that was on the left.   See why we needed the temp variable above?
                        numbers[i + 1] = numbers[i];

                        // Now we assign the value that is in temp, the smaller value, to the location that was just vacated by the larger number
                        numbers[i] = temp;

                        // Indicate that we did a swap, which means we need to continue to check the remaining values.
                        swapped = true;
                    }
                }
            } while (swapped == true);

            return Array.AsReadOnly<int>(numbers);
        }

        static int PromptUserForNumber(string message, int tries = 1)
        {
            try
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                return int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }

            if (tries >= MAX_INPUT_TRIES)
            {
                throw new Exception("Too many invalid input attempts.");
            }

            return PromptUserForNumber(message, tries + 1);
        }

        static ReadOnlyCollection<int> BuildNumbersArray(int numberCount)
        {
            int[] numbersArray = new int[numberCount];
            for (int i = 0; i < numberCount; i++)
            {
                int number = PromptUserForNumber("Please enter a number:");
                numbersArray[i] = number;
            }

            return Array.AsReadOnly<int>(numbersArray);
        }

        static void OutputNumbers(string preText, ReadOnlyCollection<int> numbers){
            Console.Write(preText);
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write("{0}, ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
