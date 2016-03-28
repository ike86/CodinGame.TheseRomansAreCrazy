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

            [TestMethod]
            public void ReturnsNumeral_V_If_ValueIsFive()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(5);

                result.Should().Be("V");
            }

            [TestMethod]
            public void ReturnsNumeral_VIII_If_ValueIsEigth()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(8);

                result.Should().Be("VIII");
            }
            
            [TestMethod]
            public void ReturnsNumeral_IV_If_ValueIsFour()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(4);

                result.Should().Be("IV");
            }

            [TestMethod]
            public void ReturnsNumeral_IX_If_ValueIsNine()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(9);

                result.Should().Be("IX");
            }

            [TestMethod]
            public void ReturnsNumeral_X_If_ValueIsTen()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(10);

                result.Should().Be("X");
            }

            [TestMethod]
            public void ReturnsNumeral_XXX_If_ValueIsThrity()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(30);

                result.Should().Be("XXX");
            }
            
            [TestMethod]
            public void ReturnsNumeral_XXIX_If_ValueIsTwentyNine()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(29);

                result.Should().Be("XXIX");
            }

            [TestMethod]
            public void ReturnsNumeral_XL_If_ValueIsFourty()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(40);

                result.Should().Be("XL");
            }

            [TestMethod]
            public void ReturnsNumeral_L_If_ValueIsFifty()
            {
                var subject = new RomanNumeralGenerator();

                var result = subject.Generate(50);

                result.Should().Be("L");
            }
        }
    }
}
