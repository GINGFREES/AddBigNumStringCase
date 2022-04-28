using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAdd
{
    class Program
    {
        const int MAX_NUMBERS_OF_DIGITS = 9;
        const string chars = "1234567890";

        private static readonly Dictionary<int, string> dics =
            new Dictionary<int, string>() {
                {0 ,"00" },
                {1, "10,01"},
                {2, "20,02,11"},
                {3, "30,03,12,21"},
                {4, "40,04,22,13,31"},
                {5, "50,05,23,32,14,41"},
                {6 , "60,06,15,51,42,24,33"},
                {7, "70,07,16,61,25,52,34,43" },
                {8, "80,08,17,71,62,26,53,35,44" },
                {9, "90,09,81,18,27,72,36,63,54,45"},
                {10,"91,19,28,82,73,37,46,64,55" },
                {11,"92,29,38,83,74,47,56,65" },
                {12,"93,39,48,84,75,57,66"},
                {13,"94,49,58,85,76,67"},
                {14,"95,59,68,86,77" },
                {15,"96,69,87,78" },
                {16,"97,79,88"},
                {17,"98,89" },
                {18,"99" }
            };

        private static int GetCarryNum(string numMerge, out int result)
        {
            result = -1;
            int back = -1;
            foreach(var pair in dics)
            {
                if(pair.Value.Contains(numMerge))
                {
                    result = pair.Key % 10;
                    back = pair.Key / 10;
                    break;
                }
            }
            return back;
        }
        
        private static string RandomBigNumberStr()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            var strArray = Enumerable.Repeat(chars, MAX_NUMBERS_OF_DIGITS).Select(s =>
            s[r.Next(chars.Length)]).ToArray();
            return new string(strArray).TrimStart('0');
        }

        static void Main(string[] args)
        {

            string num1 = RandomBigNumberStr();
            string num2 = RandomBigNumberStr();
            int maxLength = num2.Length >= num1.Length ? num2.Length : num1.Length;
            string numCheck1 = num1.PadLeft(maxLength, '0');
            string numCheck2 = num2.PadLeft(maxLength, '0');

            int currentCarry = 0;
            int beforeCarry = 0;
            string getResult = string.Empty;

            for (int i = (MAX_NUMBERS_OF_DIGITS - 1); i >= 0; i--)
            {
                beforeCarry = 0;
                if (currentCarry > 0)
                {
                    beforeCarry = currentCarry;
                }
                currentCarry = GetCarryNum($"{numCheck1[i]}{numCheck2[i]}", out int result);
                if (beforeCarry > 0)
                {
                    //Console.WriteLine("add 1");
                    beforeCarry = GetCarryNum($"{result}{beforeCarry}", out int result2);
                    result = result2;
                }
                getResult = $"{result}{getResult}";
            }

            if (beforeCarry > 0 || currentCarry > 0)
            {
                getResult = $"1{getResult}";
            }

            Console.WriteLine("The current result is: " + getResult);
            // Use this console to check if result is Correct
            // Also, we can defined UnitTest for this case
            //Console.WriteLine($"The correct result is :{ Convert.ToInt32(num1) + Convert.ToInt32(num2)}");

        }
    }
}
