using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodinGame.TheseRomansAreCrazy.Tests
{
    public class Test_RomanNumeralParser
    {
        [TestClass]
        public class Parse
        {
            [TestMethod]
            public void ReturnsOne_If_NumeralIs_I()
            {
                var subject = CreateSubject();

                var result = subject.Parse("I");

                result.Should().Be(1);
            }

            [TestMethod]
            public void ReturnsTwo_If_NumeralIs_II()
            {
                var subject = CreateSubject();

                var result = subject.Parse("II");

                result.Should().Be(2);
            }

            [TestMethod]
            public void ReturnsThree_If_NumeralIs_III()
            {
                var subject = CreateSubject();

                var result = subject.Parse("III");

                result.Should().Be(3);
            }

            [TestMethod]
            public void ReturnsFive_If_NumeralIs_V()
            {
                var subject = CreateSubject();

                var result = subject.Parse("V");

                result.Should().Be(5);
            }

            [TestMethod]
            public void ReturnsEigth_If_NumeralIs_VIII()
            {
                var subject = CreateSubject();

                var result = subject.Parse("VIII");

                result.Should().Be(8);
            }

            [TestMethod]
            public void ReturnsFour_If_NumeralIs_IV()
            {
                var subject = CreateSubject();

                var result = subject.Parse("IV");

                result.Should().Be(4);
            }

            private static RomanNumeralParser CreateSubject()
            {
                return new RomanNumeralParser();
            }
        }
    }
}
