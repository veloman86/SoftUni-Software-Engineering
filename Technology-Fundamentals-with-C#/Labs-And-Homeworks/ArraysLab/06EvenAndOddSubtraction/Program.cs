﻿using System;
using System.Linq;

namespace _06EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEvenNumbers = 0;
            int sumOfOddNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber % 2 == 0)
                {
                    sumOfEvenNumbers += currentNumber;
                }
                else
                {
                    sumOfOddNumbers += currentNumber;
                }
            }

            int differenceOfSums = sumOfEvenNumbers - sumOfOddNumbers;
            Console.WriteLine(differenceOfSums);
        }
    }
}
