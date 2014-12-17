namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;

    /// <summary>
    /// Describes a retry policy for rest requests.
    /// </summary>
    public interface IRetryPolicy
    {
        /// <summary>
        /// Determines whether the exception should be retried.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="attempt">The attempt. The first attempt will be 1.</param>
        /// <param name="delay">The delay.</param>
        /// <returns>Bool indicating whether the exception should be retried.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "Design choice", MessageId = "2#")]
        bool ShouldRetry(Exception exception, int attempt, out TimeSpan delay);
    }
}
