using System;
using System.Text;
using B20_Ex01_02;

namespace B20_Ex01_03
{
    class Program
    {
        private static void Main()
        {
            RunSandClockProgram();
        }

        public static void RunSandClockProgram()
        {
            int clockHeight = getInputFromUser();
            B20_Ex01_02.Program.DrewSandClock(clockHeight);

        }

        private static int getInputFromUser()
        {
            bool isValidInput = false;
            int clockHeight = -1;

            Console.WriteLine("Please enter the number of lines for the sand clock:");

            while (!isValidInput)
            {
                string inputClockHeight = System.Console.ReadLine();
                bool isSuccess = int.TryParse(inputClockHeight, out clockHeight);
                if(isSuccess && clockHeight> 0)
                {
                    isValidInput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invaild input. try again.");
                }
            }

            return clockHeight;
        }
    }
}
