using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utils{
    public class SearchApplication{
        private IInputOutput inputOutputHandler;

        public SearchApplication(IInputOutput inputOutputHandler){
            this.inputOutputHandler = inputOutputHandler;
        }

        public void RunSearch(Func<int,ReadOnlyCollection<int>,int> action){
            try{
                int numberCount = inputOutputHandler.PromptUserForNumber("Enter the how many numbers that will be searched:");
                ReadOnlyCollection<int> originalNumbers = inputOutputHandler.BuildNumbersArray(numberCount);
                int desiredNumber = inputOutputHandler.PromptUserForNumber("Enter the desired number to be found:");
                int result = action(desiredNumber, originalNumbers);
                
                if(result == -1){
                    inputOutputHandler.Output("Number not found.");
                }else{
                    inputOutputHandler.Output($"Number found at index: {result}");
                }
            }catch(Exception ex){
                inputOutputHandler.Output($"Error occurred {ex.Message}");
            }

            inputOutputHandler.Output("Press any key to quit the application.");
            inputOutputHandler.ReadInput();
        }
    }
}