using System;

namespace olottech_ci_cd
{
    // <summary>
    ///     Service to handle age-related calculations.
    /// </summary>
    public class AgeService : IAgeService
    {
        #region Public Methods

        /// <summary>
        ///     Determines whether the specified age corresponds to an adult.
        /// </summary>
        /// <param name="age">The age.</param>
        /// <returns>
        ///   <c>true</c> if the specif ied age is adult; otherwise, <c>false</c>.
        /// </returns>
        public IsAdultResponseModel IsAdult(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException(nameof(age));
            }

            var result = new IsAdultResponseModel
            {
                IsAdult = age > 21
            };

            return result;
        }

        #endregion
    }
}
