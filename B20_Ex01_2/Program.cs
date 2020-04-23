using System;
using System.Text;

namespace B20_Ex01_02
{
    public class Program
    {
        private static void Main()
        {
            const int k_ClockHeight = 5;
            DrewSandClock(k_ClockHeight);
        }

        public static void DrewSandClock(int i_ClockHeight)
        {
            int NumOfSpeaces = 0;
            StringBuilder sandClock = new StringBuilder();

            CreateSandClock(sandClock, i_ClockHeight, NumOfSpeaces);
            Console.Write(sandClock);
        }

        public static void CreateSandClock(StringBuilder i_SandClock, int i_ClockHeight, int i_NumOfSpeaces)
        {
            if(i_ClockHeight == 1)
            {
                CreateLineOfAstrix(i_SandClock, i_ClockHeight, i_NumOfSpeaces);                      
            }
            else if(i_ClockHeight>1)
            {
                CreateLineOfAstrix(i_SandClock, i_ClockHeight, i_NumOfSpeaces);
                CreateSandClock(i_SandClock, i_ClockHeight - 2, i_NumOfSpeaces + 1);
                CreateLineOfAstrix(i_SandClock, i_ClockHeight, i_NumOfSpeaces);
             }
        }

        public static void CreateLineOfAstrix(StringBuilder i_SandClock, int i_NumOfStars, int i_NumOfSpeaces)
        {
            i_SandClock.Append(' ', i_NumOfSpeaces);
            i_SandClock.Append('*', i_NumOfStars);
            i_SandClock.AppendLine();
        }
    }
}
