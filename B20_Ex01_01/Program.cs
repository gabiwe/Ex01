using System;
using System.Text;

namespace B20_Ex01_01
{
    public class Program
    { 
        private static void Main()
        {
            RunNumbersCheck();
        }

        public static void RunNumbersCheck()
        {
            const int k_NumOfInputs = 3, k_LengthOfInput = 9;
            int countOfPowerOf2 = 0, countOfOnes = 0, countOfAscendingNumbers = 0, maxNumber = 0, minNumber = int.MaxValue;
            float averageOfOnes = 0, averageOfZeros = 0;
            StringBuilder outputDecimalNumbers = new StringBuilder();

            System.Console.WriteLine("Please enter {0} binary numbers with {1} digits each:", k_NumOfInputs, k_LengthOfInput);
            for(int i = 0; i < k_NumOfInputs; i++)
            {
                string currentBinaryNumber = getInputFromUser(k_LengthOfInput); 
                int currentDecimalNumber = convertBinaryStringToInt(currentBinaryNumber); 
                countOfOnes += getCountOfOnesOfBinaryNumber(currentBinaryNumber);
                countOfPowerOf2 += Convert.ToInt32(checkIfPowerOf2(currentBinaryNumber));
                countOfAscendingNumbers += Convert.ToInt32(checkIfAscendingNumber(currentDecimalNumber));
                maxNumber = Math.Max(maxNumber, currentDecimalNumber);
                minNumber = Math.Min(minNumber, currentDecimalNumber);
                outputDecimalNumbers.AppendFormat("{0} ", currentDecimalNumber);
            }

            averageOfOnes = calculateAverageOfOnes(countOfOnes, k_NumOfInputs);
            averageOfZeros = calculateAverageOfZeros(countOfOnes, k_NumOfInputs, k_LengthOfInput);
            printNumbersAndStatistics(outputDecimalNumbers.ToString(), averageOfOnes, averageOfZeros, countOfPowerOf2, countOfAscendingNumbers, maxNumber, minNumber);
        }

        private static int convertBinaryStringToInt(string i_BinaryNumberInput)
        {
            int binaryNumber, decimalNumber = 0, exponent = 1;
            bool isSuccess = int.TryParse(i_BinaryNumberInput, out binaryNumber);

            if(isSuccess)
            {
                while(binaryNumber > 0)
                {
                    decimalNumber +=  (binaryNumber % 10) * exponent;
                    binaryNumber /= 10;
                    exponent *= 2;
                }
            }

            return decimalNumber;
        }

        private static float calculateAverageOfOnes(int i_CountOfOnes, int i_NumOfInputs)
        {
            float averageOfOne = (float)i_CountOfOnes / i_NumOfInputs;

            return averageOfOne;
        }

        private static float calculateAverageOfZeros(int i_CountOfOnes, int i_NumOfInputs, int i_LengthOfInput)
        {
            float averageOfZero = (float)(i_NumOfInputs * i_LengthOfInput - i_CountOfOnes) / i_NumOfInputs;

            return averageOfZero;
        }

        private static bool checkIfAscendingNumber(int i_InputNumber)
        {
            bool isAscendingNumber = true; 
            int prevDigit = i_InputNumber % 10;
            int currentDigit;

            i_InputNumber /= 10;
            while(i_InputNumber > 0)
            {
                currentDigit = i_InputNumber % 10;
                if(currentDigit >= prevDigit)
                {
                    isAscendingNumber = false;
                    break;
                }

                i_InputNumber /= 10;
                prevDigit = currentDigit;
            }

            return isAscendingNumber;

        } 

        private static bool checkIfPowerOf2(string i_InputNumber)
        {
            return getCountOfOnesOfBinaryNumber(i_InputNumber) == 1;
        }

        private static int getCountOfOnesOfBinaryNumber(string i_BinaryNumber)
        {
            int onesCounter = 0;

            for(int i = 0; i < i_BinaryNumber.Length; i++)
            {
                onesCounter += i_BinaryNumber[i] - '0';
            }

            return onesCounter;
        }

        private static string getInputFromUser(int i_LengthOfInput)
        {
            string inputBinaryNumber = "";
            bool isValidInput = false;

            while(!isValidInput)
            {
                inputBinaryNumber = System.Console.ReadLine();
                if(checkIfValidInput(inputBinaryNumber, i_LengthOfInput))
                {
                    isValidInput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invaild input. try again.");
                }
            }

            return inputBinaryNumber;
        }

        private static bool checkIfValidInput(string i_userInput, int i_LengthOfInput)
        {
            bool isValidInput = false;

            if(checkNumberOfDigits(i_userInput, i_LengthOfInput) && checkIfBinaryNumber(i_userInput))
            {
                isValidInput = true;
            }

            return isValidInput;
        }

        private static bool checkNumberOfDigits(string i_userInput, int i_LengthOfInput)
        {
            return i_userInput.Length == i_LengthOfInput;
        }

        private static bool checkIfBinaryNumber(string i_userInput)
        {
            bool isValidInput = true;

            for(int i = 0; i < i_userInput.Length; i++)
            {
                if(i_userInput[i] != '0' && i_userInput[i] != '1')
                {
                    isValidInput = false;
                    break;
                }
            }

            return isValidInput;
        }

        private static void printNumbersAndStatistics(string i_DecimalNumbers, float i_AverageOfOnes, float i_AverageOfZeros, int i_CountOfPowerOf2,
                                                        int i_CountOfAscendingNumbers, int i_MaxNumber, int i_MinNumber)
        {
            string outputMessage = string.Format(
@"The numbers are: {0}.
The average number of one digits in each binary number is {1}.
The average number of zero digits in each binary number is {2}. 
There are {3} numbers which are a power of 2.
There are {4} numbers which are an ascending series.
The maximum decimal number is {5}.
The minimum decimal number is {6}.",
                i_DecimalNumbers, i_AverageOfOnes, i_AverageOfZeros, i_CountOfPowerOf2, i_CountOfAscendingNumbers, i_MaxNumber, i_MinNumber);

            System.Console.WriteLine(outputMessage);
        }

    }
}
