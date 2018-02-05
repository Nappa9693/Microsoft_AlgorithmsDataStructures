using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utils{
    ///<summary>
    /// Interface to be implemented by all Input/Output handlers that is used
    /// by the application to handle retrieving data and outputing data.
    ///</summary>
    public interface IInputOutput{
        int PromptUserForNumber(string message, int tries = 1);
        
        ReadOnlyCollection<int> BuildNumbersArray(int numberCount);

        void OutputNumbers(string preText, ReadOnlyCollection<int> numbers);
    }
}