using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

namespace SelectionSort
{
    ///<summary>
    /// The selection sort works iterating through the array, getting the current value
    /// associated with the current index, comparing that value to the rest of the elements
    /// of the array to find the smallest value, moving the smallest value to the front
    /// which is the zero position initialy, and repeating this process until the elements
    /// of the array are sorted.
    ///</summary>
    class Program
    {
        const int MAX_INPUT_TRIES = 3;

        static void Main(string[] args)
        {
            var consoleInputOutputHandler = new ConsoleInputOutputHandler(MAX_INPUT_TRIES);
            var simpleApp = new SortApplication(consoleInputOutputHandler);
            simpleApp.RunSort(PerformSelectionSort);
        }

        static ReadOnlyCollection<int> PerformSelectionSort(ReadOnlyCollection<int> nums){
            int[] numbers = new int[nums.Count];
            nums.CopyTo(numbers, 0);

            for(int outerIndex = 0; outerIndex < numbers.Length; outerIndex++){
                // Set the smallest value to the current value before comparing to the
                // other values.
                int smallestValue = numbers[outerIndex];

                // Initialize the inner index to the current index + 1.
                // We do this because the previous indexes already have the 
                // smaller values and we are comparing the values after the current.
                for(int innerIndex = outerIndex + 1; innerIndex < numbers.Length; innerIndex++){
                    int currentInnerValue = numbers[innerIndex];

                    if(currentInnerValue < smallestValue){
                        // The current smallest value is not the smallest.
                        // Move the current smallest to the current inner position
                        // and set the smallest to the the current inner value.
                        // Note: This step is necessary to preserve the original
                        // number values while sorting else they will be overwritten
                        // by the smallest value in the array.
                        numbers[innerIndex] = smallestValue;
                        smallestValue = currentInnerValue;
                    }
                }

                // Set the smallest value to the current index.
                numbers[outerIndex] = smallestValue;
            }

            return Array.AsReadOnly(numbers);
        }
    }
}
