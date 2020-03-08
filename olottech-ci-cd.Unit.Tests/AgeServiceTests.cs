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

            [Theory, AutoData]
            public void WhenIsNotAdult_ThenReturnFalse([Range(0,17)]int value)
            {
                // Arrange
                var sut = new AgeService();

                // Act
                var result = sut.IsAdult(value);

                // Assert
                result.IsAdult.Should().BeFalse();
            }

            [Fact]
            public void WhenIsAdult_ThenReturnTrue()
            {
                // Arrange
                var sut = new AgeService();
                var value = _fixture.Create<int>() + 18;

                // Act
                var result = sut.IsAdult(value);

                // Assert
                result.IsAdult.Should().BeTrue();
            }
        }
    }
}
