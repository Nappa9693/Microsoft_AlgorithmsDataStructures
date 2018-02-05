using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utils{

    ///<summary>
    /// The SimpleApplication class is a representation for a simple application
    /// that handles prompting the user, gathering the needed input, and running the 
    /// the given action and outputing the results.
    ///</summary>
    public class SimpleApplication{
        private IInputOutput inputOutputHandler;

        public SimpleApplication(IInputOutput inputOutputHandler){
            this.inputOutputHandler = inputOutputHandler;
        }

        public void Run(Func<ReadOnlyCollection<int>, ReadOnlyCollection<int>> action){
            try{
                int numberCount = inputOutputHandler.PromptUserForNumber("Enter the how many numbers that will be sorted:");
                ReadOnlyCollection<int> originalNumbers = inputOutputHandler.BuildNumbersArray(numberCount);
                ReadOnlyCollection<int> sortedNumbers = action(originalNumbers);
                
                inputOutputHandler.OutputNumbers("Before: ", originalNumbers);
                inputOutputHandler.OutputNumbers("After: ", sortedNumbers);
            }catch(Exception ex){
                Console.WriteLine($"Error occurred {ex.Message}");
            }

            Console.WriteLine("Press any key to quit the application.");
            Console.ReadLine();
        }
    }
}