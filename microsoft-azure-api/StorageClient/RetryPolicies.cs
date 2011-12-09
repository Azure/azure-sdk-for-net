//-----------------------------------------------------------------------
// <copyright file="RetryPolicies.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the RetryPolicies class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Net;

    /// <summary>
    /// Defines some standard retry policies.
    /// </summary>
    public static class RetryPolicies
    {
        /// <summary>
        /// Indicates the default minimum backoff value that will be used for a policy returned by <see cref="RetryPolicies.RetryExponential (Int32, TimeSpan)"/>. 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Backoff",
            Justification = "Backoff is a compound term.")]
        public static readonly TimeSpan DefaultMinBackoff = TimeSpan.FromSeconds(3);

        /// <summary>
        /// Indicates the default maximum backoff value that will be used for a policy returned by <see cref="RetryPolicies.RetryExponential (Int32, TimeSpan)"/>. 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Backoff",
            Justification = "Backoff is a compound term.")]
        public static readonly TimeSpan DefaultMaxBackoff = TimeSpan.FromSeconds(90);
        
        /// <summary>
        /// Indicates the default client backoff value that will be used by a service client, if no other retry policy has been specified.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Backoff",
            Justification = "Backoff is a compound term.")]
        public static readonly TimeSpan DefaultClientBackoff = TimeSpan.FromSeconds(30);
        
        /// <summary>
        /// Indicates the default retry count that will be used by a service client, if no other retry policy has been specified.
        /// </summary>
        public static readonly int DefaultClientRetryCount = 3;

        /// <summary>
        /// Returns a retry policy that performs no retries.
        /// </summary>
        /// <returns>The retry policy.</returns>
        public static RetryPolicy NoRetry()
        {
            return () =>
            {
                return (int retryCount, Exception lastException, out TimeSpan retryInterval) =>
                    {
                        retryInterval = TimeSpan.Zero;
                        return false;
                    };
            };
        }

        /// <summary>
        /// Returns a retry policy that retries a specified number of times, with a specified fixed time interval between retries.
        /// </summary>
        /// <param name="retryCount">A non-negative number indicating the number of times to retry.</param>
        /// <param name="intervalBetweenRetries">The time interval between retries. Use <see cref="System.TimeSpan.Zero"/> to specify that the operation
        /// should be retried immediately.</param>
        /// <returns>The retry policy.</returns>
        public static RetryPolicy Retry(int retryCount, TimeSpan intervalBetweenRetries)
        {
            CommonUtils.AssertInBounds("currentRetryCount", retryCount, 0, int.MaxValue);
            CommonUtils.AssertInBounds("intervalBetweenRetries", intervalBetweenRetries, TimeSpan.Zero, TimeSpan.MaxValue);

            return () =>
            {
                return (int currentRetryCount, Exception lastException, out TimeSpan retryInterval) =>
                {
                    retryInterval = intervalBetweenRetries;
                    return currentRetryCount < retryCount;
                };
            };
        }

        /// <summary>
        /// Returns a policy that retries a specified number of times with a randomized exponential backoff scheme.
        /// </summary>
        /// <param name="retryCount">A non-negative number indicating the number of times to retry.</param>
        /// <param name="deltaBackoff">The multiplier in the exponential backoff scheme.</param>
        /// <returns>The retry policy.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Backoff",
            Justification = "Backoff is a compound term.")]
        public static RetryPolicy RetryExponential(int retryCount, TimeSpan deltaBackoff)
        {
            return RetryExponential(retryCount, DefaultMinBackoff, DefaultMaxBackoff, deltaBackoff);
        }

        /// <summary>
        /// Returns a policy that retries a specified number of times with a randomized exponential backoff scheme.
        /// </summary>
        /// <param name="retryCount">A non-negative number indicating the number of times to retry.</param>
        /// <param name="minBackoff">The minimum backoff interval.</param>
        /// <param name="maxBackoff">The maximum backoff interval.</param>
        /// <param name="deltaBackoff">The multiplier in the exponential backoff scheme.</param>
        /// <returns>The retry policy.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Backoff",
            Justification = "Backoff is a compound term.")]
        public static RetryPolicy RetryExponential(int retryCount, TimeSpan minBackoff, TimeSpan maxBackoff, TimeSpan deltaBackoff)
        {
            CommonUtils.AssertInBounds("currentRetryCount", retryCount, 0, int.MaxValue);
            CommonUtils.AssertInBounds("minBackoff", minBackoff, TimeSpan.Zero, TimeSpan.MaxValue);
            CommonUtils.AssertInBounds("maxBackoff", maxBackoff, TimeSpan.Zero, TimeSpan.MaxValue);
            CommonUtils.AssertInBounds("deltaBackoff", deltaBackoff, TimeSpan.Zero, TimeSpan.MaxValue);

            return () =>
            {
                return (int currentRetryCount, Exception lastException, out TimeSpan retryInterval) =>
                {
                    if (currentRetryCount < retryCount)
                    {
                        Random r = new Random();
                        int increment = (int)((Math.Pow(2, currentRetryCount) - 1) * r.Next((int)(deltaBackoff.TotalMilliseconds * 0.8), (int)(deltaBackoff.TotalMilliseconds * 1.2)));
                        int timeToSleepMsec = (int)Math.Min(minBackoff.TotalMilliseconds + increment, maxBackoff.TotalMilliseconds);

                        retryInterval = TimeSpan.FromMilliseconds(timeToSleepMsec);
                        return true;
                    }

                    retryInterval = TimeSpan.Zero;
                    return false;
                };
            };
        }
    }
}
