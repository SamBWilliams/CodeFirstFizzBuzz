using NUnit.Framework;
using FizzBuzzNotCore;

namespace Tests
{
    public class Tests
    {


        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(1, "1 is not a multiple of 3 or 5")]
        public void TestFizzBuzz(int n, string expected)
        {
            var actual = FizzBuzzGame.checkNumberToTest(n);
            Assert.AreEqual(expected, actual);
        }
    }

}