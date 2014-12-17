namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// RetryPolicyFactory class.
    /// </summary>
    public static class RetryPolicyFactory
    {
        /// <summary>
        /// Returns the policy for a custom exponential retry.
        /// </summary>
        /// <param name="minBackOff">The minimum backoff.</param>
        /// <param name="maxBackOff">The maximum backoff.</param>
        /// <param name="deltaBackOff">The delta backoff.</param>
        /// <param name="maxRetryCount">The number of times the operation will be attempted before giving up.</param>
        /// <param name="randomizationTolerance">The randomization tolerance.</param>
        /// <returns>
        /// The retry policy for a custom exponential retry.
        /// </returns>
        public static IRetryPolicy CreateExponentialRetryPolicy(
            TimeSpan minBackOff, TimeSpan maxBackOff, TimeSpan deltaBackOff, int maxRetryCount, double randomizationTolerance)
        {
            return new RetryExponential(minBackOff, maxBackOff, deltaBackOff, maxRetryCount, randomizationTolerance);
        }

        /// <summary>
        /// Returns the policy for a default exponential retry.
        /// </summary>
        /// <returns>The retry policy for a default exponential retry.</returns>
        public static IRetryPolicy CreateExponentialRetryPolicy()
        {
            return new RetryExponential(RetryDefaultConstants.DefaultMinBackOff, RetryDefaultConstants.DefaultMaxBackOff, RetryDefaultConstants.DefaultBackOff, RetryDefaultConstants.DefaultRetryCount, RetryDefaultConstants.DefaultRandomizationQuotient);
        }
    }
}
