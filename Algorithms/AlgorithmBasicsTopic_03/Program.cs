using System;

namespace AlgorithmBasicsTopic_03
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                int baseNum = PromptUserForNumber("Please provide the base number for the exponent calculation.");
                int powerNum = PromptUserForNumber("Please enter the power to calculate the exponent with.");

                Console.WriteLine("edxCalculateExponent result:");
                edxCalculateExponent(baseNum, powerNum);

                Console.WriteLine("CalculateExponent result:");
                Console.WriteLine(CalculateExponent(baseNum, powerNum));
            }catch(FormatException){
                Console.WriteLine("Please enter a valid integer value.");
            }catch(OverflowException){
                Console.WriteLine("You entered an integer too large or too small in value. " 
                    + "Try a number between -2,147,483,648 to 2,147,483,647");
            }catch(Exception ex){
                Console.WriteLine($"Unexpected error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        // Original algorithm shown in lesson.
        static void edxCalculateExponent(int numBase, int exp){
            int result = 1;

            while (exp > 0)
            {
                result = result * numBase;
                exp--;
            }

            Console.WriteLine($"Result is {result}");
        }

        // My implementation of the algorithm shown in the lesson.
        static int CalculateExponent(int baseNum, int power){
            int result = 1;

            for(int i = 0; i < power; i++){
                result = result * baseNum;
            }

            return result;
        }

        static int PromptUserForNumber(string message){
            Console.WriteLine(message);
            string valString = Console.ReadLine();
            return int.Parse(valString);
        }
    }
}
