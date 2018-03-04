using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

namespace LinearSearch
{
    ///<summary>
    /// The Linear Search algorithm works by searching a given list/array
    /// by iterating through the list/array starting at the first element and
    /// moving to the next elemenet until either the desired item is found
    /// or it has reached the end of the list/array.
    ///</summary>
    class Program
    {
        const int MAX_INPUT_TRIES = 3;

        static void Main(string[] args)
        {
            var consoleInputOutputHandler = new ConsoleInputOutputHandler(MAX_INPUT_TRIES);
            var searchApplication = new SearchApplication(consoleInputOutputHandler);
            searchApplication.RunSearch(GetSearchedNumberIndex);
        }

        static int GetSearchedNumberIndex(int desiredNumber, ReadOnlyCollection<int> numbers){
            for(int index=0; index < numbers.Count; index++){
                var currentNumber = numbers[index];
                if(currentNumber == desiredNumber){
                    return index;
                }
            }

            return -1;
        }
    }
}
