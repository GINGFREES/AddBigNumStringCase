using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAdd
{
    public class Program
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

        public static int GetCarryNum(string numMerge, out int result)
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

        public static string GetResult(string numCheck1, string numCheck2, int maxLength)
        {
            string getResult = string.Empty;
            int latestCarry = 0;
            int latestResult = 0;

            for (int i = (maxLength - 1); i >= 0; i--)
            {
                if (latestCarry > 0)
                {
                    latestCarry = GetCarryNum($"{numCheck1[i]}{latestCarry}", out latestResult);
                    int tempCarry = GetCarryNum($"{numCheck2[i]}{latestResult}", out latestResult);
                    if (tempCarry > 0) latestCarry = tempCarry;
                    getResult = $"{latestResult}{getResult}";
                }
                else
                {
                    latestCarry = GetCarryNum($"{numCheck1[i]}{numCheck2[i]}", out latestResult);
                    getResult = $"{latestResult}{getResult}";
                }
            }

            if (latestCarry > 0) getResult = $"{latestCarry}{getResult}";

            return getResult;
        }

        public static int GetLogicCarryNum(string num1, string num2, out int result)
        {
            Logic.NumberType cType1 = Logic.Instance.GetNumberType(num1);
            Logic.NumberType cType2 = Logic.Instance.GetNumberType(num2);
            int total = Logic.Instance.GetAddResult(cType1, cType2);
            result = total % 10;
            return total / 10;
        }

        public static string GetLogicResult(string num1, string num2, int maxLength)
        {
            string getResult = string.Empty;
            int latestCarry = 0;
            int latestResult = 0;

            for (int i = (maxLength - 1); i >= 0; i--)
            {
                if (latestCarry > 0)
                {
                    latestCarry = GetLogicCarryNum($"{num1[i]}", latestCarry.ToString(), out latestResult);
                    int tempCarry = GetLogicCarryNum($"{num2[i]}", latestResult.ToString(), out latestResult);
                    if (tempCarry > 0) latestCarry = tempCarry;
                    getResult = $"{latestResult}{getResult}";
                }
                else
                {
                    latestCarry = GetLogicCarryNum($"{num1[i]}", $"{num2[i]}", out latestResult);
                    getResult = $"{latestResult}{getResult}";
                }
            }
            if (latestCarry > 0) getResult = $"{latestCarry}{getResult}";

            return getResult;
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

            //int currentCarry = 0;
            //int beforeCarry = 0;
            string getResult = string.Empty;
            int latestCarry = 0;
            int latestResult = 0;

            getResult = GetResult(numCheck1, numCheck2, maxLength);
            Console.WriteLine("The current result is: " + getResult);
            getResult = GetLogicResult(numCheck1, numCheck2, maxLength);
            Console.WriteLine("The current result use Logic is :" + getResult);
            // Use this console to check if result is Correct
            // Also, we can defined UnitTest for this case
            Console.WriteLine($"The correct result is :{ Convert.ToInt32(num1) + Convert.ToInt32(num2)}");

        }
    }
}
