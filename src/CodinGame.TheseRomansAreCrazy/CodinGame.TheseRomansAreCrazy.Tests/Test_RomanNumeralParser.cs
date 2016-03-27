﻿using System;
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

            [TestMethod]
            public void ReturnsTen_If_NumeralIs_X()
            {
                var subject = CreateSubject();

                var result = subject.Parse("X");

                result.Should().Be(10);
            }
            
            [TestMethod]
            public void ReturnsThirty_If_NumeralIs_XXX()
            {
                var subject = CreateSubject();

                var result = subject.Parse("XXX");

                result.Should().Be(30);
            }
            
            [TestMethod]
            public void ReturnsNine_If_NumeralIs_IX()
            {
                var subject = CreateSubject();

                var result = subject.Parse("IX");

                result.Should().Be(9);
            }

            [TestMethod]
            public void ReturnsTwentyNine_If_NumeralIs_XXIX()
            {
                var subject = CreateSubject();

                var result = subject.Parse("XXIX");

                result.Should().Be(29);
            }

            [TestMethod]
            public void ReturnsFifty_If_NumeralIs_L()
            {
                var subject = CreateSubject();

                var result = subject.Parse("L");

                result.Should().Be(50);
            }

            [TestMethod]
            public void ReturnsOneHundred_If_NumeralIs_C()
            {
                var subject = CreateSubject();

                var result = subject.Parse("C");

                result.Should().Be(100);
            }


            [TestMethod]
            public void ReturnsThreeHundred_If_NumeralIs_CCC()
            {
                var subject = CreateSubject();

                var result = subject.Parse("CCC");

                result.Should().Be(300);
            }

            private static RomanNumeralParser CreateSubject()
            {
                return new RomanNumeralParser();
            }
        }
    }
}
