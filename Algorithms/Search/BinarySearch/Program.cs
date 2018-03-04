using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

namespace BinarySearch
{
    ///<summary>
    /// Binary search works by: 
    /// 1. first taking a sorted array/list, finding the midpoint value.
    /// 2. checking if the value is the desired value, if not it compares the desired value to the current value.
    /// 3. If the desired value is lower then we search the lower half of the array/list, else the higher half.
    /// 4. This process repeats until the value is found.
    ///</summary>
    class Program
    {
        const int MAX_INPUT_TRIES = 3;

        static void Main(string[] args)
        {
            var consoleInputOutputHandler = new ConsoleInputOutputHandler(MAX_INPUT_TRIES);
            var searchApplication = new SearchApplication(consoleInputOutputHandler);
            searchApplication.RunSearch(GetNumberIndexViaBinarySearch);
        }

        static int GetNumberIndexViaBinarySearch(int desiredNumber, ReadOnlyCollection<int> numbers){
            int leftSideIndex = 0;
            int rightSideIndex = numbers.Count - 1;
            int midPointIndex = (leftSideIndex + rightSideIndex) / 2;
            
            while(leftSideIndex <= rightSideIndex){
                var currentNumber = numbers[midPointIndex];
                if(currentNumber == desiredNumber){
                    return midPointIndex;
                }
                
                if(desiredNumber < currentNumber){
                    // Number may be on the left side of the array.
                    rightSideIndex = midPointIndex - 1; // Exclude previously search mid point.
                    midPointIndex = (leftSideIndex + rightSideIndex) / 2;
                }else{
                    // Number may be on the right side of the array.
                    leftSideIndex = midPointIndex + 1; // We exclude the previously searched mid point.
                    midPointIndex = (leftSideIndex + rightSideIndex) / 2;
                }
            }

            return -1;
        }
    }
}
