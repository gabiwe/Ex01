using System;

namespace B20_Ex01_4
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

            while (!isInputValid(userInput))
            {
                userInput = getUserInput();
            }

            printIfPalindrome(userInput);

            if (int.TryParse(userInput, out int intUserInput))
            {
                Console.Write("This string represents a number. ");
                printIfDividedBy5(intUserInput);
            }
            else
            {
                printUppercaseLettersCount(userInput);
            }

            exitApp();
        }

        private static string getUserInput()
        {
            Console.WriteLine(
                "Please enter an eight characters string which includes either numbers OR English letters: ");

            return Console.ReadLine();
        }

        private static bool isInputValid(string i_StringInput)
        {
            bool isValid = true;

            for (int i = 0; i < i_StringInput.Length; i++)
            {
                isValid = char.IsLetter(i_StringInput[i]);

                if (!isValid)
                {
                    break;
                }
            }

            if (!isValid)
            {
                isValid = int.TryParse(i_StringInput, out int notCare);
            }

            return isValid && i_StringInput.Length == 8;
        }

        private static void printIfPalindrome(string i_String)
        {
            int startIndex = 0;
            int endIndex = i_String.Length - 1;
            bool isInputPalindrome = isPalindrome(startIndex, endIndex, i_String);

            if (isInputPalindrome)
            {
                Console.WriteLine("This string is a palindrome.");
            }
            else
            {
                Console.WriteLine("This string isn't a palindrome.");
            }
        }

        private static bool isPalindrome(int i_StartIndex, int i_EndIndex, string i_String)
        {
            bool isPalindromeResult = true;
            bool stopTheRecursion = i_EndIndex - i_StartIndex == 1 || i_StartIndex == i_EndIndex;

            if (!stopTheRecursion)
            {
                isPalindromeResult = i_String[i_StartIndex] == i_String[i_EndIndex] && 
                               isPalindrome(++i_StartIndex, --i_EndIndex, i_String);
            }
            
            return isPalindromeResult;
        }

        private static void printIfDividedBy5(int i_Number)
        {
            Math.DivRem(i_Number, 5, out int remainder);

            if (remainder == 0)
            {
                Console.WriteLine("The number is divided by 5.");
            }
            else
            {
                Console.WriteLine("The number isn't divided by 5.");
            }
        }

        private static void printUppercaseLettersCount(string i_String)
        {
            int uppercaseLettersCount = countUppercaseLetters(i_String);

            Console.WriteLine(string.Format("This string has {0} uppercase letters.", uppercaseLettersCount));
        }

        private static int countUppercaseLetters(string i_String)
        {
            int uppercaseLettersCount = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (char.IsUpper(i_String[i]))
                {
                    uppercaseLettersCount++;
                }
            }

            return uppercaseLettersCount;
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
