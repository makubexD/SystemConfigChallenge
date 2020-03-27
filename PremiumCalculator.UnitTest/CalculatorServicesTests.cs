using System;
using Moq;
using NUnit.Framework;
using PremiumCalculator.ServicesCore;
using PremiumCalculator.ServicesCore.Months;
using PremiumCalculator.ServicesCore.States;

namespace PremiumCalculator.UnitTest
{
    public class CalculatorServicesTests
    {
        private Mock<IStateFactory> _stateFactory;
        private CalculatorServices _calculatorServices;
        private Mock<IMonthFactory> _monthFactory;

        [SetUp]
        public void Setup()
        {
            _stateFactory = new Mock<IStateFactory>();
            _monthFactory = new Mock<IMonthFactory>();
            _calculatorServices = new CalculatorServices(_stateFactory.Object);
        }

        [Test]
        [TestCase(2, 7, 1980, 30, true)]
        public void ValidateBirthDate_DateOfBirthDifferentFromAge_ReturnTrue(int day, int month, int year, int age, bool expectedResult)
        {
            var dateOfBirth = new DateTime(year, month, day);

            var result = _calculatorServices.ValidateBirthDate(dateOfBirth, age);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(26, 8, 1974, "NY", 45, "150.00")]
        public void GetPremium_WhenStateIsNyAndMonthOfBirthIsAugustAndAgeBetween18And45_Return150(int day, int month, int year, string state, int age, string expectedResult)
        {

            _monthFactory.Setup(d => d.ResolveByName(month.ToString())).Returns(new August());
            _stateFactory.Setup(d => d.ResolveByName(state)).Returns(new NYService(_monthFactory.Object));

            var dateOfBirth = new DateTime(year, month, day);

            var result = _calculatorServices.GetPremium(dateOfBirth, state, age);

            Assert.That(result.Premium, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(12, 1, 1971, "NY", 49, "200.50")]
        public void GetPremium_WhenStateIsNyAndMonthOfBirthIsJanuaryAndAgeBetween46And65_Return200_50(int day, int month, int year, string state, int age, string expectedResult)
        {
            _monthFactory.Setup(d => d.ResolveByName(month.ToString())).Returns(new January());
            _stateFactory.Setup(d => d.ResolveByName(state)).Returns(new NYService(_monthFactory.Object));

            var dateOfBirth = new DateTime(year, month, day);

            var result = _calculatorServices.GetPremium(dateOfBirth, state, age);

            Assert.That(result.Premium, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(18, 11, 1970, "AL", 49, "85.50")]
        public void GetPremium_WhenStateIsAlAndMonthOfBirthIsNovemberAndAgeBetween18And65_Return85_50(int day, int month, int year, string state, int age, string expectedResult)
        {
            _monthFactory.Setup(d => d.ResolveByName(month.ToString())).Returns(new November());
            _stateFactory.Setup(d => d.ResolveByName(state)).Returns(new ALService(_monthFactory.Object));

            var dateOfBirth = new DateTime(year, month, day);

            var result = _calculatorServices.GetPremium(dateOfBirth, state, age);

            Assert.That(result.Premium, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(18, 12, 1952, "AL", 67, "175.20")]
        public void GetPremium_WhenStateIsAkAndMonthOfBirthIsDecemberAndAgeHigherThan65_Return175_20(int day, int month, int year, string state, int age, string expectedResult)
        {
            _monthFactory.Setup(d => d.ResolveByName(month.ToString())).Returns(new December());
            _stateFactory.Setup(d => d.ResolveByName(state)).Returns(new AKService(_monthFactory.Object));

            var dateOfBirth = new DateTime(year, month, day);

            var result = _calculatorServices.GetPremium(dateOfBirth, state, age);

            Assert.That(result.Premium, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(18, 12, 1955, "AL", 64, "125.16")]
        public void GetPremium_WhenStateIsAkAndMonthOfBirthIsDecemberAndAgeBetween18And64_Return125_16(int day, int month, int year, string state, int age, string expectedResult)
        {
            _monthFactory.Setup(d => d.ResolveByName(month.ToString())).Returns(new December());
            _stateFactory.Setup(d => d.ResolveByName(state)).Returns(new AKService(_monthFactory.Object));

            var dateOfBirth = new DateTime(year, month, day);

            var result = _calculatorServices.GetPremium(dateOfBirth, state, age);

            Assert.That(result.Premium, Is.EqualTo(expectedResult));
        }
    }
}

