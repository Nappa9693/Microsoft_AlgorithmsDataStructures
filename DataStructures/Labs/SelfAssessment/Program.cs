﻿using System;
using System.Linq;

namespace SelfAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Average of Numbers assessment results:");
            AverageOfNumbersAssessment();

            Console.WriteLine("Reverse Characters assessment results:");
            ReverseCharacters();

            Console.WriteLine("K-th smallest assessment results:");
            KthSmallestElement();

            Console.WriteLine("Maximum difference assessment results:");
            MaxDifference();

            Console.WriteLine("Depth Of Nesting results:");
            DepthOfNesting();
        }

        static void AverageOfNumbersAssessment(){
            // Note: While the self assessment allows you to enter code on the site itself,
            // I have decided to put my solution in here for recording purposes.
            int[] sample1 = new int[]{ 1,3,1,1 }; // Avg should be 2.
            int[] sample2 = new int[] { -3, 2 }; // Avg should be 0
            int[] sample3 = new int[] { -2, 4, -1, 6}; // Avg should be 2.

            // This is one way using built in methods.
            Console.WriteLine(Math.Round(sample1.Average(), MidpointRounding.ToEven));
            Console.WriteLine(Math.Round(sample2.Average(), MidpointRounding.ToEven));
            Console.WriteLine(Math.Round(sample3.Average(), MidpointRounding.ToEven));

            // Alternative without using built in methods (except for the rounding).
            double sum = 0;
            foreach(int number in sample1){
                sum += (double)number;
            }
            var result = Math.Round(sum / (double)sample1.Length, MidpointRounding.ToEven);
            Console.WriteLine(result);
        }

        static void ReverseCharacters(){
            var sample1 = "abcad";
            var letters = sample1.ToCharArray();
            var firstLetter = letters[0];
            var lastLetter = letters[letters.Length -1];

            Array.Reverse(letters);
            letters[0] = firstLetter;
            letters[letters.Length - 1] = lastLetter;
            Console.WriteLine(new string(letters));
        }

        static void KthSmallestElement(){
            var sample = new int[] {7, 2, 1, 6, 1};
            var k = 3;
            Array.Sort(sample);
            Console.WriteLine(sample[k]);
        }

        static void MaxDifference(){
            var sample = new int[] {3, 2, 9, 5};
            Array.Sort(sample);
            var smallest = sample[0];
            var largest = sample[sample.Length - 1];

            Console.WriteLine(largest - smallest);
        }

        static void DepthOfNesting(){
            string example1 = "a(())b()";

            int openParenthesisCount = example1.Count(letter => letter == '(');
            int closeParenthesisCount = example1.Count(letter => letter == ')');

            // Check the open and close parenthesis count. if they
            // are not equal we have an unmatched parenthesis.
            // Note: This is the first phase of mismatch checking.
            if(openParenthesisCount != closeParenthesisCount){
                Console.WriteLine("0");
                return;
            }

            int highestDepthCount = 0;
            int currentDepthCount = 0;
            foreach(char letter in example1){
                if(letter == '('){
                    currentDepthCount++;
                }else if(letter == ')'){
                    // if the current depth count is zero or below
                    // then we have a mismatched closed parenthesis.
                    if(currentDepthCount <= 0){
                        Console.WriteLine("0");
                        return;
                    }else{
                        currentDepthCount--;
                    }
                }

                if(highestDepthCount < currentDepthCount){
                    highestDepthCount = currentDepthCount;
                }
            }

            Console.WriteLine(highestDepthCount);
        }
    }
}
