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
            public void ReturnsOne_If_NumeralIsI()
            {
                var subject = CreateSubject();

                var result = subject.Parse("I");

                result.Should().Be(1);
            }

            [TestMethod]
            public void ReturnsTwo_If_NumeralIsII()
            {
                var subject = CreateSubject();

                var result = subject.Parse("II");

                result.Should().Be(2);
            }

            [TestMethod]
            public void ReturnsThree_If_NumeralIsIII()
            {
                var subject = CreateSubject();

                var result = subject.Parse("III");

                result.Should().Be(3);
            }

            private static RomanNumeralParser CreateSubject()
            {
                return new RomanNumeralParser();
            }
        }
    }
}
