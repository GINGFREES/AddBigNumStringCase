using System;
using System.Collections.Generic;
namespace TestAdd
{
    public class Logic
    {
        private static Lazy<Logic> _lazyInstance = new Lazy<Logic>(new Logic());
        public static Logic Instance => _lazyInstance.Value;

        ~Logic() => _lazyInstance = null;

        public enum NumberType : int
        {
            ZERO = 1 << 0,
            ONE = 1 << 1,
            TWO = 1 << 2,
            THREE = 1 << 3,
            FOUR = 1 << 4,
            FIVE = 1 << 5,
            SIX = 1 << 6,
            SEVEN = 1 << 7,
            EIGHT = 1 << 8,
            NINE = 1 << 9,
        }

        private Dictionary<string, NumberType> numberByteDics
            = new Dictionary<string, NumberType>()
            {
                {"0", NumberType.ZERO},
                {"1", NumberType.ONE },
                {"2", NumberType.TWO },
                {"3", NumberType.THREE },
                { "4", NumberType.FOUR},
                { "5", NumberType.FIVE},
                { "6", NumberType.SIX},
                { "7", NumberType.SEVEN},
                { "8", NumberType.EIGHT },
                { "9", NumberType.NINE}
            };

        private Dictionary<NumberType, int> resultDics = new Dictionary<NumberType, int>()
        {
            {NumberType.ZERO | NumberType.ONE, 1 },
            {NumberType.ZERO | NumberType.TWO, 2},
            {NumberType.ZERO | NumberType.THREE, 3},
            {NumberType.ZERO | NumberType.FOUR, 4},
            {NumberType.ZERO | NumberType.FIVE, 5},
            {NumberType.ZERO | NumberType.SIX, 6},
            {NumberType.ZERO | NumberType.SEVEN, 7},
            {NumberType.ZERO | NumberType.EIGHT, 8},
            {NumberType.ZERO | NumberType.NINE, 9},
            {NumberType.ONE | NumberType.TWO, 3},
            {NumberType.ONE | NumberType.THREE, 4},
            {NumberType.ONE | NumberType.FOUR, 5},
            {NumberType.ONE | NumberType.FIVE, 6},
            {NumberType.ONE | NumberType.SIX, 7},
            {NumberType.ONE | NumberType.SEVEN, 8},
            {NumberType.ONE | NumberType.EIGHT, 9 },
            {NumberType.ONE | NumberType.NINE, 10 },
            {NumberType.TWO | NumberType.THREE, 5},
            {NumberType.TWO | NumberType.FOUR, 6},
            {NumberType.TWO | NumberType.FIVE, 7},
            {NumberType.TWO | NumberType.SIX, 8},
            {NumberType.TWO | NumberType.SEVEN, 9},
            {NumberType.TWO | NumberType.EIGHT, 10 },
            {NumberType.TWO | NumberType.NINE, 11 },
            {NumberType.THREE | NumberType.FOUR, 7},
            {NumberType.THREE | NumberType.FIVE, 8},
            {NumberType.THREE | NumberType.SIX, 9},
            {NumberType.THREE | NumberType.SEVEN, 10},
            {NumberType.THREE | NumberType.EIGHT, 11 },
            {NumberType.THREE | NumberType.NINE, 12 },
            {NumberType.FOUR | NumberType.FIVE, 9},
            {NumberType.FOUR | NumberType.SIX, 10},
            {NumberType.FOUR | NumberType.SEVEN, 11},
            {NumberType.FOUR | NumberType.EIGHT, 12 },
            {NumberType.FOUR | NumberType.NINE, 13 },
            {NumberType.FIVE | NumberType.SIX, 11},
            {NumberType.FIVE | NumberType.SEVEN, 12},
            {NumberType.FIVE | NumberType.EIGHT, 13 },
            {NumberType.FIVE | NumberType.NINE, 14 },
            {NumberType.SIX | NumberType.SEVEN, 13},
            {NumberType.SIX | NumberType.EIGHT, 14 },
            {NumberType.SIX | NumberType.NINE, 15 },
            {NumberType.SEVEN | NumberType.EIGHT, 15 },
            {NumberType.SEVEN | NumberType.NINE, 16 },
            {NumberType.EIGHT | NumberType.NINE, 17 },
        };

        public NumberType GetNumberType(string number) => numberByteDics[number];

        public int GetAddResult(NumberType cType1, NumberType cType2)
            => (cType1 == cType2)
                   ? 2 * (int)Math.Log2((int)cType1)
                   : resultDics[cType1 | cType2];
        
    }
}
