﻿using System;

namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            runApp();
        }

        private static void runApp()
        {
            string userInput = getUserInput();
            int intUserInput;

            while (!isInputValid(userInput, out intUserInput))
            {
                userInput = getUserInput();
            }

            printTheLargestDigit(intUserInput);
            printTheSmallestDigit(intUserInput);
            printHowManyDigitsAreDividedBy3(intUserInput);
            printHowManyDigitsAreLargerThanUnitsDigit(intUserInput);
            exitApp();
        }

        private static void printHowManyDigitsAreLargerThanUnitsDigit(int i_Number)
        {
            int counter = 0;
            int unitsDigit = i_Number % 10;
            
            while (i_Number != 0)
            {
                i_Number /= 10;
                int digit = i_Number % 10;
                
                if (digit > unitsDigit)
                {
                    counter++;
                }
            }

            Console.WriteLine(string.Format("The number of digits which are larger than the units digit '{0}': {1}",
                unitsDigit, counter));
        }

        private static void printHowManyDigitsAreDividedBy3(int i_Number)
        {
            int counter = 0;

            while (i_Number != 0)
            {
                int digit = i_Number % 10;
                Math.DivRem(digit, 3, out int remainder);

                if (remainder == 0)
                {
                    counter++;
                }

                i_Number /= 10;
            }

            Console.WriteLine(string.Format("The number of digits which are divided by 3: {0}", counter));
        }

        private static void printTheSmallestDigit(int i_Number)
        {
            int smallest = 9;

            while (i_Number != 0)
            {
                int digit = i_Number % 10;
                smallest = Math.Min(digit, smallest);

                i_Number /= 10;
            }

            Console.WriteLine(string.Format("The smallest digit is: {0}", smallest));
        }

        private static void printTheLargestDigit(int i_Number)
        {
            int largest = 0;

            while (i_Number != 0)
            {
                int digit = i_Number % 10;
                largest = Math.Max(digit, largest);

                i_Number /= 10;
            }

            Console.WriteLine(string.Format("The largest digit is: {0}", largest));
        }

        private static bool isInputValid(string i_UserInput, out int o_IntUserInput)
        {

            return int.TryParse(i_UserInput, out o_IntUserInput) &&
                   i_UserInput.Length == 9;
        }

        private static string getUserInput()
        {
            Console.WriteLine(
                "Please enter a nine digits natural number: ");

            return Console.ReadLine();
        }

        private static void exitApp()
        {
            Console.WriteLine("Please enter 'Y' to exit, and any other key to continue: ");
            string userInput = Console.ReadLine();

            if (userInput != null && !userInput.Equals("Y"))
            {
                Console.WriteLine(
                    "=========================================================================================");
                runApp();
            }
        }
    }
}
