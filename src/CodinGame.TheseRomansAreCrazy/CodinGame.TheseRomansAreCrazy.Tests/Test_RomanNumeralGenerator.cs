using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodinGame.TheseRomansAreCrazy.Tests
{
    public class Test_RomanNumeralGenerator
    {
        [TestClass]
        public class Generate
        {
            [TestMethod]
            public void ReturnsNumeral_I_If_ValueIsOne()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(1);

                result.Should().Be("I");
            }

            [TestMethod]
            public void ReturnsNumeral_II_If_ValueIsTwo()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(2);

                result.Should().Be("II");
            }

            [TestMethod]
            public void ReturnsNumeral_III_If_ValueIsThree()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(3);

                result.Should().Be("III");
            }
        }
    }
}
