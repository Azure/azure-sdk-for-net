namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Retries
{
    using System;

    /// <summary>
    /// A retry policy that would never retry.
    /// </summary>
    internal class NoRetryPolicy : IRetryPolicy
    {
        /// <summary>
        /// Determines whether the exception should be retried.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="attempt">The attempt.</param>
        /// <param name="delay">The delay.</param>
        /// <returns>A boolean indicating whether the exception must be retried.</returns>
        public bool ShouldRetry(Exception exception, int attempt, out TimeSpan delay)
        {
            delay = TimeSpan.FromMilliseconds(0);
            return false;
        }
    }
}
