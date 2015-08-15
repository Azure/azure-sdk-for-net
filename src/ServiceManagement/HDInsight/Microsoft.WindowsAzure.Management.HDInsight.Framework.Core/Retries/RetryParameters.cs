namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// RetryParameters class.
    /// </summary>
    public class RetryParameters
    {
        /// <summary>
        /// Initializes a new instance of the RetryParameters class.
        /// </summary>
        /// <param name="shouldRetry">Whether or not another retry should be attempted.</param>
        /// <param name="waitTime">The amount of time to wait before the next retry.</param>
        public RetryParameters(bool shouldRetry, TimeSpan waitTime)
        {
            this.WaitTime = waitTime;
            this.ShouldRetry = shouldRetry;
        }

        /// <summary>
        /// Gets a value indicating whether or not another retry should be attempted.
        /// </summary>
        public bool ShouldRetry { get; private set; }

        /// <summary>
        /// Gets the amount of time to wait before the next retry.
        /// </summary>
        public TimeSpan WaitTime { get; private set; }
    }
}
