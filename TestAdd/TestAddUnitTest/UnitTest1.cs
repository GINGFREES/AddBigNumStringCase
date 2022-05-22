using NUnit.Framework;
using TestAdd;

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
    }
}