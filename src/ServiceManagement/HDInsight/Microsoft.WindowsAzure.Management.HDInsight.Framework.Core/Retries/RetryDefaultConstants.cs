namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines constants for retries.
    /// </summary>
    public static class RetryDefaultConstants
    {
        /// <summary>
        /// Default minimum permissible value for exponential backoff.
        /// </summary>
        public static readonly TimeSpan DefaultMinBackOff = TimeSpan.FromMinutes(0);

        /// <summary>
        /// Default maximum permissible value for exponential backoff. 
        /// </summary>
        public static readonly TimeSpan DefaultMaxBackOff = TimeSpan.FromMinutes(8);

        /// <summary>
        /// Default Retry count. Currently set to 5.
        /// </summary>
        public const int DefaultRetryCount = 5;

        /// <summary>
        /// Default backoff value 30 seconds.
        /// </summary>
        public static readonly TimeSpan DefaultBackOff = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Default percentage error to introduce in the randomized exponential backoff scheme.
        /// </summary>
        public const double DefaultRandomizationQuotient = 0.2;

        /// <summary>
        /// The HTTP operation timeout.
        /// </summary>
        public static readonly TimeSpan DefaultOperationTimeout = TimeSpan.FromSeconds(150);
    }
}
