using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

namespace InsertionSort
{
    class Program
    {
        const int MAX_INPUT_TRIES = 3;

        static void Main(string[] args)
        {
            var consoleInputOutputHandler = new ConsoleInputOutputHandler(MAX_INPUT_TRIES);
            var simpleApp = new SortApplication(consoleInputOutputHandler);
            simpleApp.RunSort(DoInsertionSort);
        }

        static ReadOnlyCollection<int> DoInsertionSort(ReadOnlyCollection<int> data){
            // Get mutable copy of the array.
            int[] arrayToSort = new int[data.Count];
            data.CopyTo(arrayToSort, 0);

            int currentValue = 0;

            // Iterate through each element of the array starting at the second element
            // because we will be checking the preceding item for the sort.
            for(int currentValIndex = 1; currentValIndex < arrayToSort.Length; currentValIndex++){
                // Get the current value.
                // Note: This value will be changed as the inner loop it run.
                currentValue = arrayToSort[currentValIndex];

                // Set the inner loop index to the current index position so
                // that we check only the preceding numbers.
                int innerIndex = currentValIndex;

                // Loop through the elements starting at the current value index
                // while working our way through the preceding items.
                // We then check to see if the current value is greater than the 
                // preceding value. If it is not we swap. Rinse and repeat until
                // until all preceding numbers are properly ordered.
                while(innerIndex > 0 && arrayToSort[innerIndex - 1] > currentValue){
                    // Current value is smaller than the preceding value. Swap positions
                    // by swapping the larger number on the left with the smaller number on the right.
                    arrayToSort[innerIndex] = arrayToSort[innerIndex - 1];
                    innerIndex--; // Go to the item preceding this current item.
                }

                // We have finally reached the point where the current value
                // is larger than the preceding item. Set the current value
                // to the appropriate index position where it is larger than
                // all preceding numbers.
                arrayToSort[innerIndex] = currentValue;
            }

            return Array.AsReadOnly(arrayToSort);
        }
    }
}
