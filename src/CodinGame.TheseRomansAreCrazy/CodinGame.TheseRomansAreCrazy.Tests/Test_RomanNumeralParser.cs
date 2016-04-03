namespace CodinGame.TheseRomansAreCrazy.Tests
{
    using System.IO;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            [TestMethod]
            public void ReturnsFourty_If_NumeralIs_XL()
            {
                var subject = CreateSubject();

                var result = subject.Parse("XL");

                result.Should().Be(40);
            }

            [TestMethod]
            public void ReturnsNinety_If_NumeralIs_XC()
            {
                var subject = CreateSubject();

                var result = subject.Parse("XC");

                result.Should().Be(90);
            }

            [TestMethod]
            public void ReturnsTwoHundredAndNinety_If_NumeralIs_CCXC()
            {
                var subject = CreateSubject();

                var result = subject.Parse("CCXC");

                result.Should().Be(290);
            }

            [TestMethod]
            public void ReturnsFiveHundred_If_NumeralIs_D()
            {
                var subject = CreateSubject();

                var result = subject.Parse("D");

                result.Should().Be(500);
            }

            [TestMethod]
            public void ReturnsOneTousand_If_NumeralIs_M()
            {
                var subject = CreateSubject();

                var result = subject.Parse("M");

                result.Should().Be(1000);
            }

            [TestMethod]
            public void ReturnsFourTousand_If_NumeralIs_MMMM()
            {
                var subject = CreateSubject();

                var result = subject.Parse("MMMM");

                result.Should().Be(4000);
            }

            [TestMethod]
            public void ReturnsFourHundred_If_NumeralIs_CD()
            {
                var subject = CreateSubject();

                var result = subject.Parse("CD");

                result.Should().Be(400);
            }

            [TestMethod]
            public void ReturnsNineHundred_If_NumeralIs_CM()
            {
                var subject = CreateSubject();

                var result = subject.Parse("CM");

                result.Should().Be(900);
            }

            [TestMethod]
            public void ReturnsThreeTousandAndNineHundred_If_NumeralIs_MMMCM()
            {
                var subject = CreateSubject();

                var result = subject.Parse("MMMCM");

                result.Should().Be(3900);
            }
            
            [TestMethod]
            public void ReturnsProperNumer_For_AllValues___File()
            {
                // Arrange
                var lines = File.ReadAllLines(@"./romans_3999.csv")
                    .Select(l => l.Split(';'));
                var subject = CreateSubject();

                foreach (var line in lines)
                {
                    var value = int.Parse(line[0]);
                    var romanNumeral = line[1];

                    // Act
                    var result = subject.Parse(romanNumeral);

                    // Assert
                    result.Should().Be(value, $"because {romanNumeral} is {value}");
                }
            }
            
            [TestMethod]
            public void ReturnsThirtyNine_If_NumeralIs_XXXIX()
            {
                var subject = CreateSubject();

                var result = subject.Parse("XXXIX");

                result.Should().Be(39);
            }
            
            [TestMethod]
            public void ReturnsThreeHundredAndNinety_If_NumeralIs_CCCXC()
            {
                var subject = CreateSubject();

                var result = subject.Parse("CCCXC");

                result.Should().Be(390);
            }

            private static RomanNumeralParser CreateSubject()
            {
                return new RomanNumeralParser();
            }
        }
    }
}