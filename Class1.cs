using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace class1
{
    public class NegativeException : ApplicationException
    {

        public NegativeException(string arg1)
        { 
        }
    }

    [TestFixture]
    public class TestCalculator
    {
        Calculator Calc;

        [SetUp]
        public void Setup()
        {
            Calc = new Calculator();
        }

        [Test]
        public void EmptyString_ReturnZero()
        {
            int result = Calc.Add("");
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase("5", 5)]
        [TestCase("25", 25)]
        public void GivenSingleNr_ReturnsTheNr(string input, int Expected)
        {
            int result = Calc.Add(input);
            Assert.That(result, Is.EqualTo(Expected));
        }

        [Test]
        [TestCase("5,7", 12)]
        [TestCase("1,2", 3)]
        [TestCase("9,1017", 9)]
        public void Given2Nrs_ReturnsSum(string input, int Expected)
        {
            //int Result = Calc.Add("5,7");
            //Assert.That(Result, Is.EqualTo(12));
            int Result = Calc.Add(input);
            Assert.That(Result, Is.EqualTo(Expected));
        }

        [Test]
        [TestCase("5,9,3", 17)]
        [TestCase("", 0)]
        [TestCase("5", 5)]
        [TestCase("5\n9,3,13,123,1", 154)]
        [TestCase("5\n9\n3\n13\n123\n1", 154)]
        public void GivenManyNrs_ReturnsSum(string input, int Expected)
        {
            int Result = Calc.Add(input);
            Assert.That(Result, Is.EqualTo(Expected));
        }

        [Test]
        public void GivenDelimeter_ReturnSum()
        {
            int result = Calc.Add("//;\n1;2");
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase("5", 5)]
        [TestCase("2005", 0)]
        [TestCase("5,2005", 5)]
        [TestCase("5,1000", 1005)]
        [TestCase("5,1001", 5)]
        public void GivenNrsGT1000_IgnoreThoseGT1000(string Input, int Expected)
        {
            int Result = Calc.Add(Input);
            Assert.That(Result, Is.EqualTo(Expected));
        }
        //[Test]
        //public void GivenNegative_ReturnErrorAndNegNrs()
        //{
        //    int result = Calc.Add("-1,-2");
        //    Assert.Throws(typeof(NegativeException), '');

        //}
    }

    public class Calculator
    {

        public int Add(string numbers)
        {
            string delimeter = ",";

            if (string.IsNullOrEmpty(numbers))
                return 0;

            //// test if first 2 characters are // - indicating that the delimeter is contained in the sent string
            if (numbers.Length > 2)
            {
                if (numbers.Substring(0, 2) == "//")
                {
                    numbers = numbers.Substring(2, numbers.Length - 2);
                    string[] parts1 = numbers.Split('\n');
                    delimeter = parts1[0];
                    numbers = numbers.Substring(2, numbers.Length - 2);
                }
            }


            //if (numbers.Contains(","))
            //{
            //    var Res = numbers.Split(',');
            //    return int.Parse(Res[0]) + int.Parse(Res[1]);
            //}

            if (numbers.Contains(",") || numbers.Contains("\n") || numbers.Contains(delimeter))
            {
                int result = 0;
                
                char[] delimiters = new char[] { ',', '\n', delimeter[0] };
                string[] parts = numbers.Split(delimiters);//, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parts.Length; i++)
                {
                    //if (int.Parse(parts[1]) < 0)
                    //{
                    //    throw NegativeException(parts[1]);
                    //    return 0;
                    //}
                    if (int.Parse(parts[i]) <= 1000)
                      result += int.Parse(parts[i]);
                }
                //var Res = numbers.Split(',');
                //return int.Parse(Res[0]) + int.Parse(Res[1]);
                return result;
            }

            //if (int.Parse(numbers) < 0)
            //{
            //    throw NegativeException(numbers);
            //    return 0;
            //}

            if (int.Parse(numbers) <= 1000)
                return int.Parse(numbers);
            else
                return 0;
        }
    }
}
