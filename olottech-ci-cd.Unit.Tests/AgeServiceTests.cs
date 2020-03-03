using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace olottech_ci_cd.Unit.Tests
{
    public class AgeServiceTests
    {
        #region Members and Methods

        private static readonly Fixture _fixture = new Fixture();

        #endregion

        public class TheIsAdultMethod
        {
            [Fact]
            public void WhenAgeIsNegative_ThenThrowArgumentException()
            {
                // Arrange
                var sut = new AgeService();
                var value = _fixture.Create<int>() * -1;

                // Act
                Action action = () => sut.IsAdult(value);

                // Assert
                action.Should().Throw<ArgumentException>();
            }

            [Fact]
            public void WhenAgeIs0_ThenReturnNotAdult()
            {
                // Arrange
                var sut = new AgeService();

                // Act
                var result = sut.IsAdult(0);

                // Assert
                result.IsAdult.Should().BeFalse();
            }

            [Theory, AutoData]
            public void WhenAgeIsBetween1And16_ThenReturnNotAdult([Range(1,17)]int value)
            {
                // Arrange
                var sut = new AgeService();

                // Act
                var result = sut.IsAdult(value);

                // Assert
                result.IsAdult.Should().BeFalse();
            }

            [Fact]
            public void WhenAgeIs18_ThenReturnAdult()
            {
                // Arrange
                var sut = new AgeService();

                // Act
                var result = sut.IsAdult(18);

                // Assert
                result.IsAdult.Should().BeTrue();
            }

            [Fact]
            public void WhenAgeIsAbove18_ThenReturnAdult()
            {
                // Arrange
                var sut = new AgeService();
                var value = _fixture.Create<int>() + 19;

                // Act
                var result = sut.IsAdult(value);

                // Assert
                result.IsAdult.Should().BeTrue();
            }
        }
    }
}
