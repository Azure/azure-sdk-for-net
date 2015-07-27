namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for an RetryPolicy.
    /// </summary>
    public interface IRetryPolicy
    {
        /// <summary>
        /// Gets or sets the number of times the operation will be attempted before giving up.
        /// </summary>
        int MaxAttemptCount { get; set; }
        
        /// <summary>
        /// Provides the retry paramters for the appropriate retry policy.
        /// </summary>
        /// <param name="currentRetryCount">Specifies the current count of attempted retries.</param>
        /// <param name="exception">Specifies the error associated with the latest retry.</param>
        /// <returns>The retry paramters for the appropriate retry policy.</returns>
        RetryParameters GetRetryParameters(int currentRetryCount, Exception exception);
    }
}
