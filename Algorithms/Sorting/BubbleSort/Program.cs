using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

// This is for Topic 1 Bubble Sort and provides a small console application
// to demonstrate the Bubble sort algorithm.
namespace BubbleSort
{
    class Program
    {
        const int MAX_INPUT_TRIES = 3;

        static void Main(string[] args)
        {
            var consoleInputOutputHandler = new ConsoleInputOutputHandler(MAX_INPUT_TRIES);
            var simpleApp = new SimpleApplication(consoleInputOutputHandler);
            simpleApp.Run(PerformBubbleSort);
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
    }
}
