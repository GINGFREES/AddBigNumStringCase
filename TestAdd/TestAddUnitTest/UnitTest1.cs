using NUnit.Framework;
using TestAdd;
using System;

namespace TestAddUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoCarry()
        {
            int carry = Program.GetCarryNum("12", out int result);
            Assert.AreEqual(carry, 0);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TestWithCarry()
        {
            int carry = Program.GetCarryNum("98", out int result);
            Assert.AreEqual(1, carry);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void TestForAdd()
        {
            string result = Program.GetResult("9", "9", 1);
            Assert.AreEqual("18", result);

            result = Program.GetResult("8", "1", 1);
            Assert.AreEqual("9", result);

            result = Program.GetResult("19", "09", 2);
            Assert.AreEqual("28", result);

            result = Program.GetResult("99", "88", 2);
            Assert.AreEqual("187", result);
        }

        [Test]
        public void TestGetNumberType()
        {
            int number = 7;
            Assert.AreEqual(Logic.NumberType.SEVEN, Logic.Instance.GetNumberType(number.ToString()));
        }

        [Test]
        public void TestForLogicEnumGet()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    Assert.AreEqual((i + j), Logic.Instance.GetAddResult((Logic.NumberType)(1 << i), (Logic.NumberType)(1 << j)), $"i: {i}, {(Logic.NumberType)(1 << i)}, j:{j}, {(Logic.NumberType)(1 << j)}");

                }
            }
        }

        [Test]
        public void TestForLogicNoCarry()
        {
            int carry = Program.GetLogicCarryNum("1", "2", out int result);
            Assert.AreEqual(carry, 0);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TestLogicWithCarry()
        {
            int carry = Program.GetLogicCarryNum("9", "8", out int result);
            Assert.AreEqual(1, carry);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void TestForLogicAdd()
        {
            string result = Program.GetLogicResult("9", "9", 1);
            Assert.AreEqual("18", result);

            result = Program.GetLogicResult("8", "1", 1);
            Assert.AreEqual("9", result);

            result = Program.GetLogicResult("19", "09", 2);
            Assert.AreEqual("28", result);

            result = Program.GetLogicResult("99", "88", 2);
            Assert.AreEqual("187", result);
        }
    }
}