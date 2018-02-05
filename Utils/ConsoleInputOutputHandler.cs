using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utils
{
    // TODO: Implement interface for input/output once available.
    public class ConsoleInputOutputHandler : IInputOutput
    {
        public int MaxTries {get; set;}

        public ConsoleInputOutputHandler(int maxTries){
            MaxTries = maxTries;
        }

        public int PromptUserForNumber(string message, int tries = 1)
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

            if (tries >= MaxTries)
            {
                throw new Exception("Too many invalid input attempts.");
            }

            return PromptUserForNumber(message, tries + 1);
        }

        public ReadOnlyCollection<int> BuildNumbersArray(int numberCount)
        {
            int[] numbersArray = new int[numberCount];
            for (int i = 0; i < numberCount; i++)
            {
                int number = PromptUserForNumber("Please enter a number:");
                numbersArray[i] = number;
            }

            return Array.AsReadOnly<int>(numbersArray);
        }

        public void OutputNumbers(string preText, ReadOnlyCollection<int> numbers){
            Console.Write(preText);
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write("{0}, ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
