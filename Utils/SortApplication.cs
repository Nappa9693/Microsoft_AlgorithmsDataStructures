using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utils{

    ///<summary>
    /// The SimpleApplication class is a representation for a simple application
    /// that handles prompting the user, gathering the needed input, and running the 
    /// the given action and outputing the results.
    ///</summary>
    public class SortApplication{
        private IInputOutput inputOutputHandler;

        public SortApplication(IInputOutput inputOutputHandler){
            this.inputOutputHandler = inputOutputHandler;
        }

        public void RunSort(Func<ReadOnlyCollection<int>, ReadOnlyCollection<int>> action){
            try{
                int numberCount = inputOutputHandler.PromptUserForNumber("Enter the how many numbers that will be sorted:");
                ReadOnlyCollection<int> originalNumbers = inputOutputHandler.BuildNumbersArray(numberCount);
                ReadOnlyCollection<int> sortedNumbers = action(originalNumbers);
                
                inputOutputHandler.OutputNumbers("Before: ", originalNumbers);
                inputOutputHandler.OutputNumbers("After: ", sortedNumbers);
            }catch(Exception ex){
                inputOutputHandler.Output($"Error occurred {ex.Message}");
            }

            inputOutputHandler.Output("Press any key to quit the application.");
            inputOutputHandler.ReadInput();
        }
    }
}