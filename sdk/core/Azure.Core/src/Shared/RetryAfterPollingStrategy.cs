// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="OperationPollingStrategy"/> of which the interval is from
    /// retry-after header of service response.
    /// </summary>
    internal class RetryAfterPollingStrategy : OperationPollingStrategy
    {
        private TimeSpan lastRetryAfter { get; set; }

        /// <summary>
        /// Create a <see cref="RetryAfterPollingStrategy"/> with a default retry-after value which normally
        /// comes from the initial response of an LRO operation.
        /// </summary>
        /// <param name="defaultRetryAfter">Default retry-after value.</param>
        public RetryAfterPollingStrategy(TimeSpan defaultRetryAfter)
        {
            lastRetryAfter = defaultRetryAfter;
        }

        /// <summary>
        /// Get the polling interval from the max value of retry-after header of given service response and <paramref name="suggestedInterval"/>.
        /// If retry-after header is not found, adopt the value of last retry-after header.
        /// </summary>
        /// <param name="response">Service response which might carry retry-after header.</param>
        /// <param name="suggestedInterval">Suggested pollingInterval.</param>
        /// <returns>Max value of retry-after header and <paramref name="suggestedInterval"/>.</returns>
        public override TimeSpan GetNextWait(Response response, TimeSpan suggestedInterval)
        {
            if (TryGetRetryAfter(response, out TimeSpan? retryAfter))
            {
                lastRetryAfter = retryAfter!.Value;
            }
            return Max(lastRetryAfter, suggestedInterval);
        }
    }
}
