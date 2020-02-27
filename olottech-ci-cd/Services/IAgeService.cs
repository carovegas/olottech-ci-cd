namespace olottech_ci_cd
{
    /// <summary>
    ///     Interface for a service to handle age-related calculations.
    /// </summary>
    public interface IAgeService
    {
        #region Public Methods

        /// <summary>
        ///     Determines whether the specified age corresponds to an adult.
        /// </summary>
        /// <param name="age">The age.</param>
        /// <returns>
        ///   <c>true</c> if the specified age is adult; otherwise, <c>false</c>.
        /// </returns>
        IsAdultResponseModel IsAdult(int age);

        #endregion
    }
}
